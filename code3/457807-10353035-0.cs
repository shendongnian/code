    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct InputRecord
    {
      internal short eventType;
      internal KeyEventRecord keyEvent;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct KeyEventRecord
    {
      internal bool keyDown;
      internal short repeatCount;
      internal short virtualKeyCode;
      internal short virtualScanCode;
      internal char uChar;
      internal int controlKeyState;
    }
    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern bool PeekConsoleInput(IntPtr hConsoleInput, out InputRecord buffer, int numInputRecords_UseOne, out int numEventsRead);
    
    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern bool ReadConsoleInput(IntPtr hConsoleInput, out InputRecord buffer, int numInputRecords_UseOne, out int numEventsRead);
    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern IntPtr GetStdHandle(int nStdHandle);
    static Nullable<InputRecord> PeekConsoleEvent()
    {
      InputRecord ir;
      int num;
      if (!PeekConsoleInput(GetStdHandle(-10), out ir, 1, out num))
      {
        //TODO process error
      }
      if (num != 0)
        return ir;
      return null;
    }
    static InputRecord ReadConsoleInput()
    {
      InputRecord ir;
      int num;
      if (!ReadConsoleInput(GetStdHandle(-10), out ir, 1, out num))
      {
        //TODO process error
      }
      return ir;
    }
    static bool PeekEscapeKey()
    {
      for (; ; )
      {
        var ev = PeekConsoleEvent();
        if (ev == null)
        {
          Thread.Sleep(10);
          continue;
        }
        if (ev.Value.eventType == 1 && ev.Value.keyEvent.keyDown && ev.Value.keyEvent.virtualKeyCode == 27)
        {
          ReadConsoleInput();
          return true;
        }
        if (ev.Value.eventType == 1 && ev.Value.keyEvent.keyDown)
          return false;
        ReadConsoleInput();
      }
    }
