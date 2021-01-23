    if (this.DesignMode)
    {
      // design time only stuff
    }
    else
    {
      // runtime only stuff.
      foreach (int i in percentages)
      {
        ComboBox.Items.Add(String.Format("{0}%", i));
      }
    }
