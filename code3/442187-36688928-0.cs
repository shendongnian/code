    private static bool IsDayLightSavingsEnabled()
    {
      try
      {
        var result = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\TimeZoneInformation", "DynamicDaylightTimeDisabled", 1);
        return !Convert.ToBoolean(result); //0 - Checked/enabled,  1 - Unchecked/disabled
      }
      catch
      { }
      return false;
    }
