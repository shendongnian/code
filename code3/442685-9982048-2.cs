    public class RightClickButton : Button
    {
        public event RoutedEventHandler RightClick;
        private bool _clicked = false;
        public RightClickButton()
        {
            this.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(RightClickButton_MouseRightButtonDown);
            this.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(RightClickButton_MouseRightButtonUp);
        }
        // Subclasses can't invoke this event directly, so supply this method
        protected void TriggerRightClickEvent(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (RightClick != null)
                RightClick(this, e);
        }
        void RightClickButton_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.IsPressed = true;
            CaptureMouse();
            _clicked = true;
        }
        void RightClickButton_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ReleaseMouseCapture();
            if(this.IsMouseOver && _clicked)
            {
                if (RightClick != null)
                    RightClick.Invoke(this, e);
            }
            _clicked = false;
            this.IsPressed = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.IsMouseCaptured)
            {
                bool isInside = false;
                VisualTreeHelper.HitTest(
                    this,
                    d =>
                    {
                        if (d == this)
                        {
                            isInside = true;
                        }
                        return HitTestFilterBehavior.Stop;
                    },
                    ht => HitTestResultBehavior.Stop,
                    new PointHitTestParameters(e.GetPosition(this)));
                if (isInside)
                    this.IsPressed = true;
                else
                    this.IsPressed = false;
            }
        }
    }
