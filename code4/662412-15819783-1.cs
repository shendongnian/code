    [ServiceContractAttribute]
    public interface IMyContract
    {
      [OperationContractAttribute]
      public void PopulateData(ref CustomDataType data);
    }
