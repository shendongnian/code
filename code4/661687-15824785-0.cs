    public partial class BottomPanel : UserControl
    {
        public BottomPanel()
        {
            InitializeComponent();
        }
        private void ExecuteOkCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (DataContext == null) return;
            var viewModel = ((BottomPanelViewModel)DataContext).Host;
            if (viewModel != null) viewModel.ExecuteOkCommand(sender, e);
        }
        private void CanExecuteOkCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (DataContext == null) return;
            var viewModel = ((BottomPanelViewModel)DataContext).Host;
            if (viewModel != null) viewModel.CanExecuteOkCommand(sender, e);
        }
        ...
    }
