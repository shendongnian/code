    SystemEvents.PowerModeChanged += OnPowerModeChange;
    private void OnPoweModerChange(object s, PowerModeChangedEventArgs e)
    {
      if(e.Mode==PowerModes.Suspend)
      {
        //Apply your operation
      }
    }
