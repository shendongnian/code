    Symbol symbol = new Symbol();
    symbol.UserSymbol = GetGraphicsPath();
    symbol.Size = 5f;
    
    LineItem lineItem = new LineItem("label", pointList, Color.Black, SymbolType.None);     
    lineItem.Line.IsVisible = _graphLineVisible; 
    lineItem.Symbol = symbol;
    zgc.GraphPane.CurveList.Add(lineItem); 
