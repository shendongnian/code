    public void CloseScreen()
    {
      if (InvokeRequired)
      {
        this.Invoke(new Action(CloseScreen), new object[] { });
        return;
      }
      active = false;
      Close();
    }
