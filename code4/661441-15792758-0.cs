    for (int i = 0; i < 67; ++i) {
      foreach (CheckBox c in this.Controls.OfType<CheckBox>()) {
        if (c.Bounds.Contains(new Point(0, loc))) {
          // do something
        }
      }
      loc += 20;
    }
