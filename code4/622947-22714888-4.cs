    [ServiceContract]
    public partial interface IDefaultInterface
    {
        [OperationContract]
        string getData1();
    }
    
    public partial class CDefaultClass : IDefaultInterface
    {
        public getData1(){ return "data 1"; }
    }
