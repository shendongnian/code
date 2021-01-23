        using System.Net;
        using System.Net.Sockets;
    
        public class UdpState
        {
            public UdpClient client;
            public IPEndPoint ep;
        }
        ...
        private void btnStartListener_Click(object sender, EventArgs e)
        {
            UdpState state = new UdpState();
            //This specifies that the UdpClient should listen on EVERY adapter
            //on the specified port, not just on one adapter.
            state.ep = new IPEndPoint(IPAddress.Any, 31337);
            //This will call bind() using the above IP endpoint information. 
            state.client = new UdpClient(state.ep);
            //This starts waiting for an incoming datagram and returns immediately.
            state.client.BeginReceive(new AsyncCallback(bytesReceived), state);
        }
        private void bytesReceived(IAsyncResult async)
        {
            UdpState state = async.AsyncState as UdpState;
            if (state != null)
            {
                IPEndPoint ep = state.ep;
                string msg = ASCIIEncoding.ASCII.GetString(state.client.EndReceive(async, ref ep));
                //either close the client or call BeginReceive to wait for next datagram here.
            }
        }
