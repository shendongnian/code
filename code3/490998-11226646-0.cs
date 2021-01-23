    public void RunMorseCode()
    {
      foreach (char c in word.ToCharArray())
      {
        string rslt = Codes[c.ToString()].Trim();
        foreach (char c2 in rslt.ToCharArray())
        {
          gridHalfFront.Opacity = 1;
          DoEvents();
          if (c2 == '.')
          {
            Thread.Sleep(1000);
          }
          else
          {
            Thread.Sleep(3000);
          }
          gridHalfFront.Opacity = 0.5;
          DoEvents();
          Thread.Sleep(500);
        }
      }
      gridHalfFront.Opacity = 1;
    }
    private void DoEvents()
    {
      Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
    }
