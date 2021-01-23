      [DllImport("User32.dll",
                 EntryPoint = "GetKeyboardState",
                 CallingConvention = CallingConvention.Winapi)]
      [return: MarshalAs(UnmanagedType.Bool)]
      internal static extern Boolean CoreGetKeyboardState(Byte[] value);
        
      public static Boolean IsKeyDown(Keys key) {
        Byte[] data = new Byte[256];
        if (!CoreGetKeyboardState(data))
          return false;
        return ((data[(int) key] & 0x80) == 0x80);
      }
      ...
      if (IsKeyDown(Keys.A) && 
          (IsKeyDown(key.Menu) || IsKeyDown(key.ShiftKey) || IsKeyDown(key.ControlKey))) {
        //TODO: You code here  
      }
