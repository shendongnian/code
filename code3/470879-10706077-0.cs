    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace UnManagedBlock
    {
        public class ConvertedCode
        {
            public uint WM_HELO_ZOOM_XYZ = RegisterWindowMessage("WM_HELO_ZOOM_XYZ");
    
            int HELO_Broadcast_Zoom_Message(
                double dbX, double dbY, double dbZ, uint uMessage) // Porting the default value for 'uMessage' is not possible
            {
                string szSharedMemory = "HELO-_Coords";
                IntPtr hMem = OpenFileMapping(FileMapAccessRights.Write, FALSE, szSharedMemory);
                if (IntPtr.Zero == hMem)
                    return 0;
                IntPtr pvHead = MapViewOfFile(hMem, FileMapAccessRights.Write, 0, 0, 0);
                if (IntPtr.Zero == pvHead)
                {
                    CloseHandle(hMem);
                    MessageBox.Show(
                        "Unable to view " + szSharedMemory, // Your code does not concat these two strings.
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return 0;
                }
    
                HELOCoordsStruct pHELOCoords = new HELOCoordsStruct();
                Marshal.PtrToStructure(pvHead, pHELOCoords);
    
                int bVersionOk = FALSE;
    
                if (1 == pHELOCoords.uMajVersion) // I think it has a typo (it was uMajorVersion)
                {
                    if (WM_HELO_ZOOM_XYZ == uMessage)
                    {
                        pHELOCoords.dbX = dbX;
                        pHELOCoords.dbY = dbY;
                        pHELOCoords.dbZ = dbZ;
                    }
                    bVersionOk = TRUE;
                }
                else
                {
                    MessageBox.Show(
                        "Unrecognized HELO- shared memory version: " +
                        pHELOCoords.uMajVersion.ToString() + "." + pHELOCoords.uMinVersion.ToString());
                }
    
                if (IntPtr.Zero != hMem)
                    CloseHandle(hMem);
                UnmapViewOfFile(pvHead);
    
                if (bVersionOk == TRUE)
                {
                    PostMessage(HWND_BROADCAST, uMessage, 0, 0);
                    return 1;
                }
                else
                    return 0;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private class HELOCoordsStruct
            {
                public uint uMajVersion;
                public uint uMinVersion;
                public uint dwReserved;
                public double dbX;
                public double dbY;
                public double dbZ;
            }
    
            [DllImport("user32", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
            public static extern uint RegisterWindowMessage([In]string lpString);
    
            [DllImport("kernel32", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
            public static extern IntPtr OpenFileMapping(FileMapAccessRights dwDesiredAccess, int bInheritHandle, [In]String lpName);
    
            [DllImport("kernel32", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
            public static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, FileMapAccessRights dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, ulong dwNumberOfBytesToMap);
    
            [DllImport("kernel32", CallingConvention = CallingConvention.StdCall)]
            public static extern int UnmapViewOfFile(IntPtr lpBaseAddress);
    
            [DllImport("kernel32", CallingConvention = CallingConvention.StdCall)]
            public static extern int CloseHandle(IntPtr hObject);
    
            [DllImport("user32.dll")]
            public static extern IntPtr PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
    
            public const int FALSE = 0, TRUE = 1;
    
            public enum FileMapAccessRights : uint
            {
                Write = 0x2,
                Read = 0x4,
                Execute = 0x20,
            }
    
            public const IntPtr HWND_BROADCAST = (IntPtr)0xffff;
        }
    }
