        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            if (!_initialized)
            {
                _WIDTH = MeasureSpec.GetSize(widthMeasureSpec);
                _HEIGHT = MeasureSpec.GetSize(heightMeasureSpec);
                InitViews();
                MeasureSpecMode widthMode = MeasureSpec.GetMode(widthMeasureSpec);
                MeasureSpecMode heightMode = MeasureSpec.GetMode(heightMeasureSpec);
                widthMeasureSpec = MeasureSpec.MakeMeasureSpec(_childView.LayoutParameters.Width, widthMode);
                heightMeasureSpec = MeasureSpec.MakeMeasureSpec(_childView.LayoutParameters.Height, heightMode);
                _childView.Measure(widthMeasureSpec, heightMeasureSpec);
                
                _initialized = true;
            }
        }
