    [ServiceContract]
    public partial interface IDefaultInterface2
    {
        [OperationContract]
        string getData2();
    }
    
    public partial class CDefaultClass2 : IDefaultInterface2
    {
        public getData2(){ return "data 2"; }
    }
