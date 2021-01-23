    class CustomControl : Control
    {
        static CustomControl()
        {
            ContentControl.ContentProperty.OverrideMetadata(typeof(CustomControl), new PropertyMetadata(null, UpdateViewModel));
        }
        private static void UpdateViewModel(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CustomControl;
            var viewModel = control.DataContext as MyViewModel;
            viewModel.CustomControl = control;
        }
    }
