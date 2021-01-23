        public Rect HostRect
        {
            get
            {
                var transform = _Host.TransformToVisual(this);
                return new Rect(transform.Transform(new Point(0, 0)), new Point(_Host.ActualWidth, _Host.ActualHeight));
            }
        }
