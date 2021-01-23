    public class MyClassWithSocket :IDisposable 
    {
        Socket myInternalSocket = null;
        public void methodThatUsesSocket()
        {
            using (var mySocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream , ProtocolType.Tcp))
            {
            //do something with socket 
           
              
            }
        }
        public void methodThatUsesInternalSocket() 
        {
            myInternalSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            //do other things
        }
        private static Socket SomethingThatReturnsSocket()
        {
           
            Socket tempSocket =  new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            return tempSocket;
        }
        public void Dispose()
        {
            myInternalSocket.Dispose();
        }
    }
