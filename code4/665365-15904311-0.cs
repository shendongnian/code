        private static bool TestForOpenHttpPort(string host)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                s.Connect(host, 80);
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
            finally
            {
                ((IDisposable)s).Dispose();
            }
        }
