        static bool setDisplayMode(int i)
        {
            DEVMODE DM = new DEVMODE();
            DM.dmSize = (short)Marshal.SizeOf(DM);
            User32.EnumDisplaySettings(null, i, ref DM);
            if (User32.ChangeDisplaySettings(ref DM, User32.CDS_TEST) == 0 && User32.ChangeDisplaySettings(ref DM, User32.CDS_UPDATEREGISTRY) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool setDisplayMode(ref DEVMODE DM)
        {
            if (User32.ChangeDisplaySettings(ref DM, User32.CDS_TEST) == 0 && User32.ChangeDisplaySettings(ref DM, User32.CDS_UPDATEREGISTRY) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static int getDMbySpecs(int H, int W, int F, int G, int B, ref DEVMODE DM)
        {
            DM.dmSize = (short)Marshal.SizeOf(DM);
            DEVMODE SelDM = new DEVMODE();
            SelDM.dmSize = (short)Marshal.SizeOf(SelDM);
            int iOMI = 0;
            for (iOMI = 0; User32.EnumDisplaySettings(null, iOMI, ref SelDM) != 0; iOMI++)
            {
                if (( B == -1 || B == SelDM.dmBitsPerPel) && ( H == -1 || H == SelDM.dmPelsHeight) && ( W == -1 || W == SelDM.dmPelsWidth) && ( G == -1 || G == SelDM.dmDisplayFlags) && ( F == -1 || F == SelDM.dmDisplayFrequency))
                    break;
            }
            if (User32.EnumDisplaySettings(null, iOMI, ref DM) == 0)
            {
                iOMI = -1;
                getCurrentRes(ref DM);
            }
            return iOMI;
        }
        static void getCurrentRes(ref DEVMODE dm)
        {
            dm = new DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(dm);
            User32.EnumDisplaySettings(null, User32.ENUM_CURRENT_SETTINGS, ref dm);
            return;
        }
