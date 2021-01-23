    public static void ActivateWindow(string appIdentifier)
    {
       var process = Process.GetProcesses().
               FirstOrDefault(actual => actual.MainWindowTitle == appIdentifier);
       if (process == null)
       {
          return;
       }
       var mainWin = process.MainWindowHandle;
       var placement = new WindowPlacement();
       placement.Length = Marshal.SizeOf(placement);
       GetWindowPlacement(mainWin, ref placement);
       if (placement.ShowCmd == SW_SHOWMINIMIZED)
       {
          ShowWindow(mainWin, (uint)WindowShowStyle.Restore);
       }
       else
       {
          Interaction.AppActivate(appIdentifier);
       }
    }
    internal struct WindowPlacement
    {
       internal int Length;
       internal int Flags;
       internal int ShowCmd;
       internal Point MinPosition;
       internal Point MaxPosition;
       internal Rectangle NormalPosition;
    }
    internal enum WindowShowStyle : uint
    {
       Hide = 0,
       ShowNormal = 1,
       ShowMinimized = 2,
       ShowMaximized = 3,
       Restore = 9,
    }
