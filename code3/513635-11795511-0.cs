    LineItem line = new LineItem(String.Empty, new[] { xPos, xPos },
                    new[] { myPane.YAxis.Scale.Min, myPane.YAxis.Scale.Max }, 
                    Color.Black, SymbolType.None);
    line.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
    line.Line.Width = 1f;
    myPane.CurveList.Add(line);
