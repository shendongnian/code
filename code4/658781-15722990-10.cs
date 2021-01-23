    public class NavigationEventMessage
    {
        public IScreen ViewModel { get; private set; }
        public NavigationEventMessage(IScreen viewModel)
        {
            ViewModel = viewModel;
        }
    }
