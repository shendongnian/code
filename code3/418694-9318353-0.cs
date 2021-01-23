    void SIP_EnabledChanged(object sender, EventArgs e) {
      int locationY = Y_START; // defined as txtNote.Location.Y when the form loads
      if (inputPanel1.Enabled) {
        locationY -= inputPanel1.Bounds.Height;
      }
      txtNote.SuspendLayout();
      txtNote.Bounds = new Rectangle(
        txtNote.Location.X,
        locationY,
        txtNote.Size.Width,
        txtNote.Size.Height
      );
      txtNote.ResumeLayout();
      txtNote.Refresh();
    }
