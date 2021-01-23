    public void NoticeAllusers(byte []buffer,StateObject state)
        {
            foreach(StateObject obj in _stateManager._connections)
            {
                if (obj != state)
                {
                    obj.workSocket.BeginSend(buffer,<parameters you>...., new AsyncCallback(OnSend) state.workSocket);
                }
            }
        }
        public void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket sock = (Socket)ar.AsyncState;
                sock.EndSend(ar);
            }
            catch { }
        }
