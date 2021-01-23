    public class TextBlockClickCommandBehavior : ZBehaviorBase<TextBlock>
    {
        public ICommand ClickCommand
        {
            get { return (ICommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }
        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(TextBlockClickCommandBehavior));
        protected override void Initialize()
        {
            this.AssociatedObject.MouseLeftButtonUp += new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonUp);
        }
        
        protected override void Uninitialize()
        {
            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.MouseLeftButtonUp -= new MouseButtonEventHandler(AssociatedObject_MouseLeftButtonUp);
            }
        }
        void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // if you want to pass a command param to CanExecute, need to add another dependency property to bind to
            if (ClickCommand != null && ClickCommand.CanExecute(null))
            {
                ClickCommand.Execute(null);
            }
        }
    }
