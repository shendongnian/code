    DbgControl dbgControl = new DbgControl();
    DbgObj g_Debugger = dbgControl.OpenDump(dumpPath, @"c:\symbols", @"c:\symbols", null);
    dynamic g_UtilExt = g_Debugger.GetExtensionObject("CrashHangExt", "Utils");
    dynamic g_VMInfo = g_Debugger.GetExtensionObject("MemoryExt", "VMInfo");
    dynamic g_LeakTrackInfo = g_VMInfo.LeakTrackInfo;
    Console.Write(g_LeakTrackInfo.IsLeakTrackLoaded());
