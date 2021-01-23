    public class NavigationService : INavigationService
    {
        // Depends on the aggregator - this is how the shell or any interested VMs will receive
        // notifications that the user wants to navigate to someplace else
        private IEventAggregator _aggregator;
        public NavigationService(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }
        // And the navigate method goes:
        public void Navigate(Type viewModelType, object modelParams)
        {
            // Resolve the viewmodel type from the container
            var viewModel = IoC.GetInstance(viewModelType, null);
            // Inject any props by passing through IoC buildup
            IoC.BuildUp(viewModel);
            // Check if the viewmodel implements IViewModelParams and call accordingly
            var interfaces = viewModel.GetType().GetInterfaces()
                   .Where(x => typeof(IViewModelParams).IsAssignableFrom(x) && x.IsGenericType);
            // Loop through interfaces and find one that matches the generic signature based on modelParams...
            foreach (var @interface in interfaces)
            {
                var type = @interface.GetGenericArguments()[0];
                var method = @interface.GetMethod("ProcessParameters");
                if (type.IsAssignableFrom(modelParams.GetType()))
                {
                    // If we found one, invoke the method to run ProcessParameters(modelParams)
                    method.Invoke(viewModel, new object[] { modelParams });
                }
            }
            // Publish an aggregator event to let the shell/other VMs know to change their active view
            _aggregator.Publish(new NavigationEventMessage(viewModel));
        }
    }
