    [ServiceContract]
    public interface IService
    {
      [OperationContract]
      [TransactionFlow(TransactionFlowOption.Allowed)]
      bool UpdateProductData(int ProdId, int Amount);
    }
