    var curve1 = new LineItem(null, new[] { 0.1, 0.5, 0.9 }, 
                 new[] { 0.8, 0.3, 0.1 }, Color.Blue, SymbolType.VDash);
    zedGraphControl1.GraphPane.CurveList.Add(curve1);
    var curve2 = new LineItem(String.Empty)
        {
            Points = new PointPairList(
                     new[] { 0.1, 0.5, 0.9 }, new[] { 0.2, 0.5, 0.9 }),
            Color = Color.Red,
            Symbol = new Symbol(SymbolType.VDash, Color.Black) 
                     { Size = 20f, Border = new Border(Color.Black, 6f)}
        };
    zedGraphControl1.GraphPane.CurveList.Add(curve2);
