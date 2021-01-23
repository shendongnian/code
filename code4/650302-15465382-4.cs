    public class ExampleUserControl : UserControl
    {
        public ExampleUserControl()
        {
            var viewModel = new ExampleUserControl_ViewModel();
            viewModel.ChildWindowsCloseRequested += OnChildWindowsCloseRequested;
            DataContext = viewModel;
        }
        private void OnChildWindowsCloseRequested()
        {
            // ... close child windows
        }
        ...
    }
