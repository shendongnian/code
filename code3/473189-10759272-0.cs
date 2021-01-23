    class Analyze {
      public event EventHandler SelectedIndexChanged;
      public Analyze() {
        ...
        size.SelectedIndexChanged += new EventHandler(size_SelectedIndexChanged);
        theform.Controls.Add(size);
      }
      void size_SelectedIndexChanged(object sender, EventArgs e) {
        if (SelectedIndexChanged != null) {
          SelectedIndexChanged(sender, e);
        }
      }
    }
