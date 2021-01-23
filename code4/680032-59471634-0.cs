using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp2
{
    class Program
    {
        public const int WM_COPYDATA = 0x4A;
        public const UInt32 WM_COMMAND = 0x0111;
        public const UInt32 IDM_MENU_SECUREDISCONNECT = 305;
        public const UInt32 PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpData;
        }
        [DllImport("User32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);
        private const string MARKER = "MARKER\n";
        static void Main(string[] args)
        {
            IntPtr destWnd = (IntPtr)int.Parse(args[0]);
          string packedargs = DAZZLE_MARKER + String.Join("\n", args[1]);
            /
            byte[] sarr = System.Text.Encoding.Unicode.GetBytes(packedargs);
            int len = sarr.Length;
            COPYDATASTRUCT CopyDataStruct;
            CopyDataStruct.dwData = (IntPtr)100;
            CopyDataStruct.cbData = (len + 1) * 2;
            CopyDataStruct.lpData = packedargs;
            int result = SendMessage(destWnd, WM_COPYDATA, 0, ref CopyDataStruct);
        }
    }
}
