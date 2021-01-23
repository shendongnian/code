    private void GetRawInputInfo(
            IntPtr rawInputHeader,
            ref IntPtr deviceHandle,
            ref bool handled,
            ref StringBuilder buffer)
        {
            try
            {
                uint cbSize = 0;
                IntPtr hRawInput;
                IntPtr ptr;
                hRawInput = rawInputHeader;
                if (UnsafeNativeMethods.GetRawInputData(
                    hRawInput,
                    Structures.RAWINPUTDATAUICOMMAND.RID_INPUT,
                    IntPtr.Zero,
                    ref cbSize,
                    (uint)Marshal.SizeOf(typeof(Structures.RAWINPUTHEADER))) == 0)
                {
                    ptr = Marshal.AllocHGlobal((int)cbSize);
                    if (ptr != IntPtr.Zero &&
                        UnsafeNativeMethods.GetRawInputData(
                        hRawInput,
                        Structures.RAWINPUTDATAUICOMMAND.RID_INPUT,
                        ptr,
                        ref cbSize,
                        (uint)Marshal.SizeOf(typeof(Structures.RAWINPUTHEADER))) == cbSize)
                {
                    Structures.RAWINPUT raw = (Structures.RAWINPUT)Marshal.PtrToStructure(ptr, typeof(Structures.RAWINPUT));
                    deviceHandle = raw.header.hDevice;
                    handled = raw.header.dwType == Structures.RAWINPUTDEVICEDWTYPE.RIM_TYPEKEYBOARD &&
                        raw.keyboard.Message == Messages.WM_KEYDOWN;
                    if (handled)
                    {
                        byte[] state = new byte[256];
                        // Force the keyboard status cache to update
                        UnsafeNativeMethods.GetKeyState(0);
                        // Note: GetKeyboardState only returns valid state when
                        // the application has focus -- this is why we weren't
                        // getting shift keys when the application was not focused
                        if (UnsafeNativeMethods.GetKeyboardState(state))
                        {
                            //StringBuilder unmanagedBuffer = new StringBuilder(64);
                            if (UnsafeNativeMethods.ToUnicode(
                                raw.keyboard.VKey,
                                raw.keyboard.MakeCode,
                                state,
                                buffer,
                                64,
                                0) <= 0)
                            {
                                buffer.Remove(0, buffer.Length);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            BLog.LogError("Error running: GetRawInputInfo()" + e.Message);
        }
        finally
        {
            if (ptr != IntPtr.Zero)
                Marshal.FreeHGlobal(ptr);
        }
    }
