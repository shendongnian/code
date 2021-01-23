    [ServiceBehavior(TransactionIsolationLevel = IsolationLevel.ReadUncommitted)]
    public class Service : IService
    {
      [OperationBehavior(TransactionScopeRequired=true,TransactionAutoComplete=true)]
      public bool UpdateProductData(int ProdId, int Amount)
      {
        DALClass objDALProd = new DALClass();
        return objDALProd.UpdateProductData(ProdId, Amount);
      }
    }
