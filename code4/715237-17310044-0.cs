            LineItem curve_x = new LineItem("x", x_values, sensor_x, Color.Red, SymbolType.None, 2.5F);
            LineItem curve_y = new LineItem("y", x_values, sensor_y, Color.Blue, SymbolType.None, 2.5F);
            LineItem curve_z = new LineItem("z", x_values, sensor_z, Color.Green, SymbolType.None, 2.5F);
            curve_x.Line.IsAntiAlias = true;
            curve_y.Line.IsAntiAlias = true;
            curve_z.Line.IsAntiAlias = true;
            myPane.XAxis.Scale.FontSpec.IsAntiAlias = true;
            myPane.YAxis.Scale.FontSpec.IsAntiAlias = true;`
