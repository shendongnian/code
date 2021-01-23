    public partial class MyView : UserControl // or whatever it is
    {
        public MyView(MyViewModel viewModel)
        {
            // Possibly ensure that viewModel is not null
            InitializeComponent();
            _myViewModel = viewModel;
            this.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new RoutedEventHandler(OnValidationRaised));
        }
        private MyViewModel _myViewModel;
        private void OnValidationRaised(object sender, RoutedEventArgs e)
        {
            var args = (System.Windows.Controls.ValidationErrorEventArgs)e;
            if (_myViewModel != null)
            {
                // Check if the error was caused by an exception
                if (args.Error.RuleInError is ExceptionValidationRule)
                {
                    // Add or remove the error from the ViewModel
                    if (args.Action == ValidationErrorEventAction.Added)
                        _myViewModel.AddUIValidationError();
                    else if (args.Action == ValidationErrorEventAction.Removed)
                        _myViewModel.RemoveUIValidationError();
                }
            }
        }
    }
