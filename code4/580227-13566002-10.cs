        public class InteractiveCommand : TriggerAction<DependencyObject>
        {
            protected override void Invoke(object parameter)
            {
                if (base.AssociatedObject != null)
                {
                    ICommand command = Command;
                    if ((command != null) && command.CanExecute(parameter))
                    {
                        command.Execute(parameter);
                    }
                }
            }
    
            #region Command
            public ICommand Command
            {
                get { return (ICommand)GetValue(CommandProperty); }
                set { SetValue(CommandProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty CommandProperty =
                DependencyProperty.Register("Command", typeof(ICommand), typeof(InteractiveCommand), new UIPropertyMetadata(null));
            #endregion
        }
