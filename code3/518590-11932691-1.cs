    var series = new LineSeries
        {
             ItemsSource = calcData,
             IndependentValuePath = "X",
             DependentValuePath = "Y",
             PolylineStyle = GetDashedLineStyle()
        };
    ...
    Style GetDashedLineStyle()
    {
        var style = new Style(typeof(Polyline));
        style.Setters.Add(new Setter(Shape.StrokeDashArrayProperty, 
                          new DoubleCollection(new[] { 5.0 })));
        return style;
    }
