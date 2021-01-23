    interface IDevice
    {
        // Some implementation
    }
    interface IProtocol : IDisposable
    {
        void Open(IDevice device, string connection);
        void Close();
        void Send(object data);
        object Receive();
    }
