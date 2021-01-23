    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    
    public class LogicalComparer : IComparer<string> {
        public int Compare(string x, string y) {
            return StrCmpLogicalW(x, y);
        }
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int StrCmpLogicalW(string s1, string s2);
    }
