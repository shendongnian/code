    using System;
    using Microsoft.Win32;
    class Powerstatus
    {
    static void Main(string[] args)
    {
        SystemEvents.PowerModeChanged +=
            new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
        Console.ReadLine();
    }
    static void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
        Console.WriteLine(e.Mode);
    }
    
    }
