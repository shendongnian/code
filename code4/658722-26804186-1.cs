    using System;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace Company.Group
    {
        public class FuncList
        {
            [DllImport("MarkEzd.dll", EntryPoint = "lmc1_Initial2", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
            public static extern int Initialize(string PathName, bool TestMode);
        }
    }
