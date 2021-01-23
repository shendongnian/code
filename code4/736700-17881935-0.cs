    public class LoadImageBehavior : Behavior<Button>
    {
        public public static static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof (ICommand), typeof (LoadImageBehavior));
        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += AssociatedObject_Click;
        }
        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            //Logic...
            
            if(Command != null && Command.CanExecute(null))
                Command.Execute(null);
            //Logic...
        }
    }
