    public Point MousePosition
        {
            get { return (Point)GetValue(MousePositionProperty); }
            set { SetValue(MousePositionProperty, value); }
        }
        public static readonly DependencyProperty MousePositionProperty =
                DependencyProperty.Register("MousePosition", typeof(Point), typeof(DesignerCanvas), new UIPropertyMetadata(point));
    
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MousePosition = e.GetPosition(this);
