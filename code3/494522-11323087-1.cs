    public void StoreScreen(Win.User32.DISPLAY_DEVICE Adaptor, Win.User32.DISPLAY_DEVICE Device)
		{
      adaptor = Adaptor.DeviceName;
      device = Device.DeviceName;
      name = string.Format("{0} on {1}", Device.DeviceString, Adaptor.DeviceString);
      Win.User32.DEVMODE dm = newDevMode();
      if (Win.User32.EnumDisplaySettings(Adaptor.DeviceName, Win.User32.ENUM_CURRENT_SETTINGS, ref dm) != 0)
      {
        isAttached = (Adaptor.StateFlags & Win.User32.DisplayDeviceStateFlags.AttachedToDesktop) > 0;
        isPrimary = (Adaptor.StateFlags & Win.User32.DisplayDeviceStateFlags.PrimaryDevice) > 0;
        mode = findMode(Adaptor.DeviceName, dm);
        if ((dm.dmFields & Win.User32.DM.PelsWidth) > 0) width = dm.dmPelsWidth;
        if ((dm.dmFields & Win.User32.DM.PelsHeight) > 0) height = dm.dmPelsHeight;
        if ((dm.dmFields & Win.User32.DM.BitsPerPixel) > 0) bpp = dm.dmBitsPerPel;
        if ((dm.dmFields & Win.User32.DM.Orientation) > 0) orientation = dm.dmOrientation;
        if ((dm.dmFields & Win.User32.DM.DisplayFrequency) > 0) frequency = dm.dmDisplayFrequency;
        if ((dm.dmFields & Win.User32.DM.DisplayFlags) > 0) flags = dm.dmDisplayFlags;
        if ((dm.dmFields & Win.User32.DM.Position) > 0)
        {
          posX = dm.dmPosition.x;
          posY = dm.dmPosition.y;
        }
      }
    }
    private static Win.User32.DEVMODE newDevMode()
    {
      Win.User32.DEVMODE dm = new Win.User32.DEVMODE();
      dm.dmDeviceName = new String(new char[31]);
      dm.dmFormName = new String(new char[31]);
      dm.dmSize = (short)Marshal.SizeOf(dm);
      return dm;
    }
