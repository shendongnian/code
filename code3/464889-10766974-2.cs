        private static readonly Point _lightSource = new Point(0.3, 0.35);
        private readonly Brush _blackPieceBrush = new RadialGradientBrush(Colors.DarkGray, Colors.Black)
        {
            GradientOrigin = _lightSource
        };
        private readonly Brush _blackPieceBorder = new SolidColorBrush(Colors.Black);
        private readonly Brush _whitePieceBrush = new RadialGradientBrush()
        {
            GradientOrigin = _lightSource,
            GradientStops = new GradientStopCollection
            {
                
                new GradientStop(Colors.WhiteSmoke,0.3),
                new GradientStop(Colors.LightGray, 1.0),
                
            }
        };
        private readonly Brush _whitePieceBorder = new SolidColorBrush(Colors.Silver);
