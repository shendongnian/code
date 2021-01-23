    public void Store()
    {
      Screens.Clear();
      uint iAdaptorNum = 0;
      Win.User32.DISPLAY_DEVICE adaptor = new Win.User32.DISPLAY_DEVICE();
			adaptor.cb = (short)Marshal.SizeOf(adaptor);
      Win.User32.DISPLAY_DEVICE dd = new Win.User32.DISPLAY_DEVICE();
      dd.cb = (short)Marshal.SizeOf(dd);
      while (Win.User32.EnumDisplayDevices(null, iAdaptorNum, ref adaptor, Win.User32.EDD_GET_DEVICE_INTERFACE_NAME))
      {
        uint iDevNum = 0;
        while (Win.User32.EnumDisplayDevices(adaptor.DeviceName, iDevNum, ref dd, Win.User32.EDD_GET_DEVICE_INTERFACE_NAME))
        {
          log.WriteFormat(LogLevel.Debug, "Adaptor {0}:{1} {2}='{3}', Device {4}='{5}', State flags = {4}",
            iAdaptorNum, iDevNum, adaptor.DeviceName, adaptor.DeviceString, dd.DeviceName, dd.DeviceString, dd.StateFlags);
          if ((dd.StateFlags & Win.User32.DisplayDeviceStateFlags.AttachedToDesktop) > 0)
            Screens.Add(new ScreenInfo(adaptor, dd));
          iDevNum++;
        }
        iAdaptorNum++;
      }
    }
