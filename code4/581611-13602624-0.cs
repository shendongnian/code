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
    
        public class TcpTable : IEnumerable<TcpRow>
        {
            public IEnumerator<TcpRow> GetEnumerator()
            {
                // You should implement this method
                throw new NotImplementedException();
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                // You should implement this method
                throw new NotImplementedException();
            }
        }
    
        public class TcpRow
        {
    
        }
    
        public static class ManagedIpHelper
        {
            public static TcpTable GetExtendedTcpTable(bool value)
            {
                // You should implement this method
                return new TcpTable();
            }
        }
    }
