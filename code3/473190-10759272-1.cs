    class Analyze {
      public event EventHandler SelectedIndexChanged;
      public Analyze(Form theform) {
        ...
        size.SelectedIndexChanged += size_SelectedIndexChanged;
        theform.Controls.Add(size);
      }
      void size_SelectedIndexChanged(object sender, EventArgs e) {
        if (SelectedIndexChanged != null) {
          SelectedIndexChanged(sender, e);
        }
      }
    }
