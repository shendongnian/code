    public Control MdiClient
    {
      get
      {
        Control result = null;
        for (int i = 0; i < Controls.Count; i++)
        {
          result = Controls[i];
          if (result.GetType().FullName == "System.Windows.Forms.MdiClient")
            return result;
        }
        return null;
      }
    }
