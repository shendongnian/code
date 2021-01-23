    class TMPDlg
    {
        // Instance variable to protect from garbage collection
        private readonly ADKCALLBACK receiveCallback;
        public TMPDlg()
        {
            receiveCallback = myOnReceive;
        }
        ...
        public void ConnectMaster(ushort port, string ip)
        {
            ...
            m_objTMPInterface.SetCallBackFn(receiveCallback);
            ...
        }
    }
