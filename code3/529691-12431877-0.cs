    DV.Measure(new System.Windows.Size(PD.PrintableAreaWidth,
                  PD.PrintableAreaHeight));
    DV.Arrange(new System.Windows.Rect(new System.Windows.Point(0, 0),
                  DV.DesiredSize));
    DV.UpdateLayout();
    PD.PrintVisual(DV, "TEST");
