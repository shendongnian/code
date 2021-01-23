    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
        }
        Point? lastPosition = null;
        RotateTransform rotateTransform;
        private void myRoot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lastPosition = null;
            if (e.ChangedButton == MouseButton.Right)
                myRoot.CaptureMouse();
        }
        private void myRoot_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
                myRoot.ReleaseMouseCapture();
        }
        private void myRoot_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                Point curPosition = Mouse.GetPosition(myRoot);
                if (lastPosition != null)
                {
                    Point centerPoint = new Point(myRoot.ActualWidth / 2, myRoot.ActualWidth / 2);
                    if (rotateTransform == null)
                        rotateTransform = (RotateTransform)myRoot.Template.FindName("rotateTransform", myRoot);
                    
                    rotateTransform.Angle = Math.Atan2(curPosition.Y - centerPoint.Y, curPosition.X - centerPoint.X) * 100;
                }
                lastPosition = curPosition;
                e.Handled = true;
            }
        }
        private void myRoot_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Canvas.SetLeft(myRoot, Canvas.GetLeft(myRoot) + e.HorizontalChange);
            Canvas.SetTop(myRoot, Canvas.GetTop(myRoot) + e.VerticalChange);
        }
    }
