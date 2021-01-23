            static class NativeMethods
            {
                
                 [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume")]
                public static extern int WaveOutSetVolume(IntPtr hwo, uint dwVolume);
        
              
                [DllImport("winmm.dll", SetLastError = true)]
                public static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);
            }
        
            public static class MSWindowsFriendlyNames
            {
                public static string WindowsXP { get { return "Windows XP"; } }
                public static string WindowsVista { get { return "Windows Vista"; } }
                public static string Windows7 { get { return "Windows 7"; } }
                public static string Windows8 { get { return "Windows 8"; } }
            }
        
            public static class SistemVolumChanger
            {
                public static void SetVolume(int value)
                {
                    if (value < 0) 
                        value = 0;
        
                    if (value > 100)
                        value = 100;
         
                    var osFriendlyName = GetOSFriendlyName();
        
                    if (osFriendlyName.Contains(MSWindowsFriendlyNames.WindowsXP))
                    {
                        SetVolumeForWIndowsXP(value);
                    }
                    else if (osFriendlyName.Contains(MSWindowsFriendlyNames.WindowsVista) || osFriendlyName.Contains(MSWindowsFriendlyNames.Windows7) || osFriendlyName.Contains(MSWindowsFriendlyNames.Windows8))
                    {
                        SetVolumeForWIndowsVista78(value);
                    }
                    else
                    {
                        SetVolumeForWIndowsVista78(value);
                    }
                }
        
                public static int GetVolume()
                {
                    int result = 100;
                    try
                    {
                        MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
                        MMDevice device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
                        result = (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
                    }
                    catch (Exception)
                    { 
                    }
        
                    return result;
                }
        
                private static void SetVolumeForWIndowsVista78(int value)
                {
                    try
                    {
                        MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
                        MMDevice device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
        
                        device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)value / 100.0f;
                    }
                    catch (Exception)
                    {            
                    }          
                }
        
                private static void SetVolumeForWIndowsXP(int value)
                {
                    try
                    {
                        // Calculate the volume that's being set
                        double newVolume = ushort.MaxValue * value / 10.0;
        
                        uint v = ((uint)newVolume) & 0xffff;
                        uint vAll = v | (v << 16);
        
                        // Set the volume
                        int retVal = NativeMethods.WaveOutSetVolume(IntPtr.Zero, vAll);
                    }
                    catch (Exception)
                    { 
                    }          
                }
        
                private static string GetOSFriendlyName()
                {
                    string result = string.Empty;
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
                    foreach (ManagementObject os in searcher.Get())
                    {
                        result = os["Caption"].ToString();
                        break;
                    }
                    return result;
                }
            }
