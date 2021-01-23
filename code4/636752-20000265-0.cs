    PrintDialog dlg = new PrintDialog();
    
    // Let it meassure to the printer's default width
    // and use an infinity height
    Grid1.Meassure(new Size(dlg.PrintableAreaWidth, double.PositiveInfinity));
    // Let it arrange to the meassured size
    Grid1.Arrange(new Rect(Grid1.DesiredSize));
    // Update the element
    Grid1.UpdateLayout();
