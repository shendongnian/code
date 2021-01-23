    public static class DefaultToolTip 
    {
      public static void Create()
      {
        ToolTip tip = new ToolTip();
        tip.ShowAlways = true;
        tip.IsBalloon = true;
        tip.AutomaticDelay = 750;
        tip.AutoPopDelay = 32767;
        return tip;
      }
    }
