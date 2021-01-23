    public class ShellViewModel : Conductor<IScreen>, IHandle<NavigationEventMessage>
    {
        private IEventAggregator _aggregator;
        private INavigationService _navigationService;
        public ShellViewModel(IEventAggregator aggregator, INavigationService _navigationService)
        {
            _aggregator = aggregator;
            _aggregator.Subscribe(this);
            _navigationService.Navigate(typeof (OneSubViewModel), null);
        }
        public void Handle(NavigationEventMessage message)
        {
            ActivateItem(message.ViewModel);
        }
    }
