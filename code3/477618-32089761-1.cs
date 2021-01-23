		Line line = new Line();
		BindingPoint startPoint = new BindingPoint(0,0);
		BindingPoint endPoint = new BindingPoint(0,0);
		var b = new Binding("X")
		{
			Source = startPoint,
			Mode = BindingMode.TwoWay
		};
		line.SetBinding(Line.X1Property, b);
		b = new Binding("Y")
		{
			Source = startPoint,
			Mode = BindingMode.TwoWay
		};
		line.SetBinding(Line.Y1Property, b);
		
		b = new Binding("X")
		{
			Source = endPoint,
			Mode = BindingMode.TwoWay
		};
		line.SetBinding(Line.X2Property, b);
		b = new Binding("Y")
		{
			Source = endPoint,
			Mode = BindingMode.TwoWay
		};
		line.SetBinding(Line.Y2Property, b);
	
	
