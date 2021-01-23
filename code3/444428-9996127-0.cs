    [Flags]
    public enum AlarmData
    {
        ForcedArm = 1,
        FinalDoor = 2,
        ExitFault = 4,
        InhibitTamper = 8,
        Display = 16,
        Rearm = 32,
        Line = 64,
        ExtendBlock = 128
    }
    
    public static Dictionary<AlarmData, string> alarmDataLookup = new Dictionary<AlarmData, string>
    {
        { AlarmData.ForcedArm, "Forced arm" },
        { AlarmData.FinalDoor, "Final door" },
        { AlarmData.ExitFault, "Exit fault" },
        { AlarmData.InhibitTamper , "Inhibit tamper" },
        { AlarmData.Display , "Display" },
        { AlarmData.Rearm , "Rearm" },
        { AlarmData.Line , "Line" },
        { AlarmData.ExtendBlock , "Extend block" }
    };
    
    public IEnumerable<string> EnumerateValues(AlarmData data)
    {
        return from pair in alarmDataLookup 
                where data.HasFlag(pair.Key) 
                select pair.Value;
    }
