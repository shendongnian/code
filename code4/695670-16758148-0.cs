     private void Window_Loaded_1(object sender, RoutedEventArgs e)
            {
                plotter.DataTransform = new Log10Transform();
    
                double[] xArray = new double[] { 15, 14, 16, 48, 50, 51 };
                double[] yArray = new double[] { 60, 63, 64, 124, 131, 144 };
    
                var xds = xArray.AsXDataSource();
                var yds = yArray.AsYDataSource();
                var ds = new CompositeDataSource(xds, yds);
    
                LineGraph hola = new LineGraph(ds);
                plotter.Children.Add(hola);
    
    
                HorizontalAxis xAxis = new HorizontalAxis
                {
                    TicksProvider = new LogarithmNumericTicksProvider(10),
                    LabelProvider = new UnroundingLabelProvider()
                };
                plotter.MainHorizontalAxis = xAxis;
    
                VerticalAxis yAxis = new VerticalAxis
                {
                    TicksProvider = new LogarithmNumericTicksProvider(10),
                    LabelProvider = new UnroundingLabelProvider()
                };
                plotter.MainVerticalAxis = yAxis;
            }
