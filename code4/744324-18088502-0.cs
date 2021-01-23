    foreach (Control control in Controls)
    {
      if (control.GetType().Equals(typeof(DropDownList)))
      {
        ((DropDownList)control).Enabled = value;
      }
    }
