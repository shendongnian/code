    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace TerminalInfo
    {
        public class TermServicesManager
        {
            [DllImport("wtsapi32.dll")]
            static extern IntPtr WTSOpenServer([MarshalAs(UnmanagedType.LPStr)] String pServerName);
            [DllImport("wtsapi32.dll")]
            static extern void WTSCloseServer(IntPtr hServer);
            [DllImport("wtsapi32.dll")]
            static extern Int32 WTSEnumerateSessions(IntPtr hServer, [MarshalAs(UnmanagedType.U4)] Int32 Reserved,
                [MarshalAs(UnmanagedType.U4)] Int32 Version, ref IntPtr ppSessionInfo, [MarshalAs(UnmanagedType.U4)] ref Int32 pCount);
            [DllImport("wtsapi32.dll")]
            static extern void WTSFreeMemory(IntPtr pMemory);
            [StructLayout(LayoutKind.Sequential)]
            private struct WTS_SESSION_INFO
            {
                public Int32 SessionID;
                [MarshalAs(UnmanagedType.LPStr)]
                public String pWinStationName;
                public WTS_CONNECTSTATE_CLASS State;
            }
            public enum WTS_CONNECTSTATE_CLASS
            {
                Active,
                Connected,
                ConnectQuery,
                Shadow,
                Disconnected,
                Idle,
                Listen,
                Reset,
                Down,
                Init
            }
            private static IntPtr OpenServer(string Name)
            {
                IntPtr server = WTSOpenServer(Name);
                return server;
            }
            private static void CloseServer(IntPtr ServerHandle)
            {
                WTSCloseServer(ServerHandle);
            }
            public static List<TerminalSessionData> ListSessions(string ServerName)
            {
                IntPtr server = IntPtr.Zero;
                List<TerminalSessionData> ret = new List<TerminalSessionData>();
                server = OpenServer(ServerName);
                try
                {
                    IntPtr ppSessionInfo = IntPtr.Zero;
                    Int32 count = 0;
                    Int32 retval = WTSEnumerateSessions(server, 0, 1, ref ppSessionInfo, ref count);
                    Int32 dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
                    Int64 current = (int)ppSessionInfo;
                    if (retval != 0)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            WTS_SESSION_INFO si = (WTS_SESSION_INFO)Marshal.PtrToStructure((System.IntPtr)current, typeof(WTS_SESSION_INFO));
                            current += dataSize;
                            ret.Add(new TerminalSessionData(si.SessionID, si.State, si.pWinStationName));
                        }
                        WTSFreeMemory(ppSessionInfo);
                    }
                }
                finally
                {
                    CloseServer(server);
                }
                return ret;
            }
        }
        public class TerminalSessionData
        {
            public int SessionId;
            public TermServicesManager.WTS_CONNECTSTATE_CLASS ConnectionState;
            public string StationName;
            public TerminalSessionData(int sessionId, TermServicesManager.WTS_CONNECTSTATE_CLASS connState, string stationName)
            {
                SessionId = sessionId;
                ConnectionState = connState;
                StationName = stationName;
            }
            public override string ToString()
            {
                return String.Format("{0} {1} {2}", SessionId, ConnectionState, StationName);
            }
        }
    }
