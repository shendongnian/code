    foreach (Control c in this.Controls)
    {
      if (c.GetType().ToString() == "System.Windows.Form.Textbox")
      {
        c.Text = "";
      }
    }
