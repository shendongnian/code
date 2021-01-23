    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Text;
    using System.Runtime.InteropServices;
    
    
        public class Wrapper
        {
            //Init
            [DllImport("BusinessLogicLib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
            public static extern int init(string loginFilePath, string remoteServerName, string[] itemsConnection, int cItems);
