    graph.CurveList.Clear();
    LineItem surf = graph.AddCurve("Surface", surfList, Color.DarkBlue, SymbolType.None);
    LineItem midr = graph.AddCurve("Mid-Radius", midrList, Color.DarkOliveGreen, SymbolType.None);
    LineItem cent = graph.AddCurve("Center", centList, Color.DarkOrange, SymbolType.None);
    LineItem furn = graph.AddCurve("Ambient", furnList, Color.Red, SymbolType.None);
