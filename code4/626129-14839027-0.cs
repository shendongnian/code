    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    using System.Text;
    using InTheHand.Net;
    using InTheHand.Net.Bluetooth;
    using System.Runtime.InteropServices;
    
    namespace BTDisco2
    {
        class Program
        {
            const int IOCTL_BTH_DISCONNECT_DEVICE = 0x41000c;
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            internal static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            ref long InBuffer,
            int nInBufferSize,
            IntPtr OutBuffer,
            int nOutBufferSize,
            out int pBytesReturned,
            IntPtr lpOverlapped);
    
            static void Main(string[] args)
            {
                var r = BluetoothRadio.PrimaryRadio;
                var h = r.Handle;
                long btAddr = BluetoothAddress.Parse("00:1b:3d:0d:ac:31").ToInt64();
                int bytesReturned = 0;
                var success = DeviceIoControl(h,
                IOCTL_BTH_DISCONNECT_DEVICE,
                ref btAddr, 8,
                IntPtr.Zero, 0, out bytesReturned, IntPtr.Zero);
    
                if (!success)
                {
                    int gle = Marshal.GetLastWin32Error();
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "failure: {0} = 0x{0:X}.", gle));
                }
                else
                {
                    Console.WriteLine("Success !");
                }
                while (!Console.KeyAvailable) System.Threading.Thread.Sleep(200);
            }
        }
    }
