    private void Add() {
      var rect = new Rectangle {
        Stroke = Brushes.Red,
        StrokeThickness = 1,
        Height = Convert.ToDouble(txtheight.Text),
        Width = 100
      };
      Items.Add(rect);
    }
