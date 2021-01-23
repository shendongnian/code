    [ServiceContract]
    public interface IShipmentManagement
    {
        [OperationContract]
        void Process(byte[] serializedShipment);
    }
