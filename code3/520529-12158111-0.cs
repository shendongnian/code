    public static class FileAssoc
    {
        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint AssocQueryString(AssocF flags, AssocStr str, string pszAssoc, string pszExtra, [Out] StringBuilder sOut, [In][Out] ref uint nOut);
        [Flags]
        public enum AssocF
        {
            Init_NoRemapCLSID = 0x1,
            Init_ByExeName = 0x2,
            Open_ByExeName = 0x2,
            Init_DefaultToStar = 0x4,
            Init_DefaultToFolder = 0x8,
            NoUserSettings = 0x10,
            NoTruncate = 0x20,
            Verify = 0x40,
            RemapRunDll = 0x80,
            NoFixUps = 0x100,
            IgnoreBaseClass = 0x200
        }
        public enum AssocStr
        {
            Command = 1,
            Executable,
            FriendlyDocName,
            FriendlyAppName,
            NoOpen,
            ShellNewValue,
            DDECommand,
            DDEIfExec,
            DDEApplication,
            DDETopic
        }
        public static string GetApplicationName(string fileExtensionIncludingDot)
        {
            uint cOut = 0;
            if (AssocQueryString(AssocF.Verify, AssocStr.FriendlyAppName, fileExtensionIncludingDot, null, null, ref cOut) != 1)
                return null;
            StringBuilder pOut = new StringBuilder((int)cOut);
            if (AssocQueryString(AssocF.Verify, AssocStr.FriendlyAppName, fileExtensionIncludingDot, null, pOut, ref cOut) != 0)
                return null;
            return pOut.ToString();
        }
    }
