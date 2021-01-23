        [DllImport("/System/Library/Frameworks/CoreServices.framework/CoreServices")]
        internal static extern short Gestalt(int selector, ref int response);
        static string m_OSInfoString = null;
        static void InitOSInfoString()
        {
            //const int gestaltSystemVersion = 0x73797376;
            const int gestaltSystemVersionMajor = 0x73797331;
            const int gestaltSystemVersionMinor = 0x73797332;
            const int gestaltSystemVersionBugFix = 0x73797333;
            int major = 0;
            int minor = 0;
            int bugFix = 0;
            Gestalt(gestaltSystemVersionMajor, ref major);
            Gestalt(gestaltSystemVersionMinor, ref minor);
            Gestalt(gestaltSystemVersionBugFix, ref bugFix);
            if (major == 10 && minor == 5)
                RunningOnLeopard = true;
            else
            {
                RunningOnLeopard = false;
                if (major == 10 && minor == 7)
                    RunningOnLion = true;
            }
            m_OSInfoString = string.Format("Mac OS X/{0}.{1}.{2}", major, minor, bugFix);
        }
