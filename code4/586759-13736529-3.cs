      string[] titles = { "Acorn", "Banana", "Chrysanthemum" };
      double col = 20.0;
      foreach (string s in titles) {
        var lbl = new Label() { Content = s };
        lbl.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        lbl.SetValue(Canvas.LeftProperty, col - (lbl.DesiredSize.Width / 2.0));
        myCanvas.Children.Add(lbl);
        col += 150.0;
      }
