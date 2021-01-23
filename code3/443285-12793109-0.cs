        public class MouseDragCustomBehavior : MouseDragElementBehavior
    {
        public static DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(MouseDragCustomBehavior));
        public static DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(MouseDragCustomBehavior));
        protected override void OnAttached()
        {
            base.OnAttached();
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                base.DragFinished += MouseDragCustomBehavior_DragFinished;
            }
        }
        private void MouseDragCustomBehavior_DragFinished(object sender, MouseEventArgs e)
        {
            var command = this.Command;
            var param = this.CommandParameter;
            if (command != null && command.CanExecute(param))
            {
                command.Execute(param);
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.DragFinished -= MouseDragCustomBehavior_DragFinished;
        }
        
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
    }
