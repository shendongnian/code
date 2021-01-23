     public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(UserControl1),
                                        new PropertyMetadata(default(ICommand), OnCommandChanged));
        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        private static void OnCommandChanged(DependencyObject dependencyObject,
                                             DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var userControl = (UserControl1) dependencyObject;
            var command = dependencyPropertyChangedEventArgs.OldValue as ICommand;
            if (command != null)
                command.CanExecuteChanged -= userControl.CommandOnCanExecuteChanged;
            command = dependencyPropertyChangedEventArgs.NewValue as ICommand;
            if (command != null)
                command.CanExecuteChanged += userControl.CommandOnCanExecuteChanged;
        }
        private void CommandOnCanExecuteChanged(object sender, EventArgs eventArgs)
        {
            IsEnabled = ((ICommand) sender).CanExecute(null);
        }
