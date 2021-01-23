    public class ExampleUserControl : UserControl
    {
        public ExampleUserControl_ViewModel ViewModel { get; private set; }
        public ExampleUserControl()
        {
            ViewModel = new ExampleUserControl_ViewModel();
            ViewModel.ChildWindowsCloseRequested += OnChildWindowsCloseRequested;
        }
        private void OnChildWindowsCloseRequested()
        {
            // ... close child windows
        }
        ...
    }
