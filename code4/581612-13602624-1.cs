    namespace NetProject
    {
        using System;
        using System.Collections.Generic;
    
        public partial class Form1
        {
            public void SomeMethod()
            {
                TcpRow row;
    
                foreach (TcpRow tcpRow in ManagedIpHelper.GetExtendedTcpTable(true))
                {
    
                }
            }
        }
    }
