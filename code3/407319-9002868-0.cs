    public class Client
            {
                NetClient m_NetClient = new NetClient();
                AutoResetEvent _lock = new AutoResetEvent(false);
                bool result;
        
                public bool Connect(string ip, int port)
                {
                    m_NetClient = new NetClient();
                    m_NetClient.Connected += _NetClient_Connected;
                    m_NetClient.Connect(ip, port);
                    _lock.WaitOne();//wait for thread to finish
                    return result;
                }
        
                private void _NetClient_Connected(object sender, EventArgs e)
                {
                    //...
                    result = e.Result;
                    _lock.Set(); //inform waiters
                }
            }
