    [StructLayout(LayoutKind.Sequential)]
            public struct Attribute
            {
                public byte AttributeID;
                public ushort Flags;
                public byte Value;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
                public byte[] VendorData;
            }
    
            static void getSMARTAttr()
            {
                try
                {
                    Attribute AtributeInfo;
                    ManagementScope Scope = new ManagementScope(String.Format("\\\\{0}\\root\\WMI", "localhost"), null);
                    Scope.Connect();
                    ObjectQuery Query = new ObjectQuery("SELECT VendorSpecific FROM MSStorageDriver_ATAPISmartData");
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
                    byte SpinRetryCount = 0x0A;
                    int Delta = 12;
                    foreach (ManagementObject WmiObject in Searcher.Get())
                    {
                        byte[] VendorSpecific = (byte[])WmiObject["VendorSpecific"];
                        for (int offset = 2; offset < VendorSpecific.Length; )
                        {
                            if (VendorSpecific[offset] == SpinRetryCount)
                            {
    
                                IntPtr buffer = IntPtr.Zero;
                                try
                                {
                                    buffer = Marshal.AllocHGlobal(Delta);
                                    Marshal.Copy(VendorSpecific, offset, buffer, Delta);
                                    AtributeInfo = (Attribute)Marshal.PtrToStructure(buffer, typeof(Attribute));
                                    Console.WriteLine("AttributeID {0}", AtributeInfo.AttributeID);
                                    Console.WriteLine("Flags {0}", AtributeInfo.Flags);
                                    Console.WriteLine("Value {0}", AtributeInfo.Value);
                                    //if you want HEX values use this line
                                    //Console.WriteLine("Value {0}", BitConverter.ToString(AtributeInfo.VendorData));
                                    //if you want INT values use this line
                                    Console.WriteLine("Data {0}", BitConverter.ToInt32(AtributeInfo.VendorData, 0));
                                }
                                finally
                                {
                                    if (buffer != IntPtr.Zero)
                                    {
                                        Marshal.FreeHGlobal(buffer);
                                    }
                                }
                            }
                            offset += Delta;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(String.Format("Exception {0} Trace {1}", e.Message, e.StackTrace));
                }
                Console.WriteLine("Press Enter to exit");
                Console.Read();
            }
