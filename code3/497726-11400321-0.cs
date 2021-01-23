using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Interop;
namespace app1
{
    public partial class window1: Window
    {
        public window1()
        {
            InitializeComponent();            
        }
        private void window1_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            source.AddHook(new HwndSourceHook(WndProc));
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            System.Windows.Forms.Message m = System.Windows.Forms.Message.Create(hwnd, msg, wParam, lParam);
            if (m.Msg == WM_COPYDATA)
            {
                // Get the COPYDATASTRUCT struct from lParam.
                COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                // If the size matches
                if (cds.cbData == Marshal.SizeOf(typeof(MyStruct)))
                {
                    // Marshal the data from the unmanaged memory block to a 
                    // MyStruct managed struct.
                    MyStruct myStruct = (MyStruct)Marshal.PtrToStructure(cds.lpData,
                        typeof(MyStruct));
                    // Display the MyStruct data members.
                    if (myStruct.Message == "Show Up")
                    {
                        this.Show();
                    }
                }
            }
            return IntPtr.Zero;
        }
        internal const int WM_COPYDATA = 0x004A;
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct MyStruct
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string Message;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct COPYDATASTRUCT
        {
            public IntPtr dwData;       // Specifies data to be passed
            public int cbData;          // Specifies the data size in bytes
            public IntPtr lpData;       // Pointer to data to be passed
        }
    }
}
