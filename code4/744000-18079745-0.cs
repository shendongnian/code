    public class TCPServerConnector
    {
        public event Action<string> DataReceived; // event
    
        public void OnRecievedData(IAsyncResult ar)
        {
            Socket sock = (Socket)ar.AsyncState;
    
            try
            {
                int nBytesRec = sock.EndReceive(ar);
                if (nBytesRec > 0)
                {
                    string sRecieved = Encoding.ASCII.GetString(m_byBuff, 0, nBytesRec);
                    if (DataReceived != null) // check if subscribed
                        DataRecieved(sRecieved); // raise event with data
                    SetupRecieveCallback(sock);
                }
                else
                {
                    Console.WriteLine("Client {0}, disconnected", sock.RemoteEndPoint);
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // rest of code is same
    }
