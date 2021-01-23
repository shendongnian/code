        static void PrintDevices(USMC_DEVICES_st um)
        {
            const int serialSize = 16;
            const int verSize = 4;
            for (var i = 0; i < um.NOD; i += IntPtr.Size)
            {
                var ser = Marshal.ReadIntPtr(um.serial, i);
                var ver = Marshal.ReadIntPtr(um.Version, i);
                // ensure we check for null pointers - just in case
                if (ver == IntPtr.Zero || ser == IntPtr.Zero) break;
                Console.WriteLine("Device {0}, \tSerial number {1}",
                                    Marshal.PtrToStringAnsi(ser, serialSize),
                                    Marshal.PtrToStringAnsi(ver, verSize));
            }
        }
