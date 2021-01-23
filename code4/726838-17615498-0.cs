        private double _top = 0;
        protected void Add()
        {
            var rect = new Rectangle();
            rect.Stroke = Brushes.Red;
            rect.StrokeThickness = 1;
            rect.Height = double.Parse(txtheight.Text);
            rect.Width = 20;
            Canvas.SetLeft(rect, 100);
            Canvas.SetTop(rect, _top);
            _top += rect.Height;
            rect.Tag = val;
            canvasboard.Children.Add(rect);
            val = val + 1;
        }
