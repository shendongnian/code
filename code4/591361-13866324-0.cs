    public class DragBehavior : Behavior<UIElement>
    {
        private Point elementStartPosition;
        private Point mouseStartPosition;
        private TranslateTransform transform = new TranslateTransform();
     
        protected override void OnAttached()
        {
            Window parent = Application.Current.MainWindow;
            AssociatedObject.RenderTransform = transform;
     
            AssociatedObject.MouseLeftButtonDown += (sender, e) => 
            {
                elementStartPosition = AssociatedObject.TranslatePoint( new Point(), parent );
                mouseStartPosition = e.GetPosition(parent);
                AssociatedObject.CaptureMouse();
            };
     
            AssociatedObject.MouseLeftButtonUp += (sender, e) =>
            {
                AssociatedObject.ReleaseMouseCapture();
            };
     
            AssociatedObject.MouseMove += (sender, e) =>
            {
                Vector diff = e.GetPosition( parent ) - mouseStartPosition;
                if (AssociatedObject.IsMouseCaptured)
                {
                    transform.X = diff.X;
                    transform.Y = diff.Y;
                }
            };
        }
    }
