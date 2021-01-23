        void DrawLineChart()
        {
          var line1 = new LineSeries();
          line1.IndependentAxis = new LinearAxis(){Orientation = AxisOrientation.X,AxisLabelStyle = GetHidenAxisStyle()};
        }
 
        private Style GetHidenAxisStyle()
        {
            Style style = new Style(typeof(AxisLabel));
            Setter st2 = new Setter(AxisLabel.BorderBrushProperty,
                                        new SolidColorBrush(Colors.White));
            Setter st3 = new Setter(AxisLabel.BorderThicknessProperty, new Thickness(0));
            Setter st4 = new Setter(AxisLabel.TemplateProperty, null);
            style.Setters.Add(st2);
            style.Setters.Add(st3);
            style.Setters.Add(st4);
            return style;
        }
