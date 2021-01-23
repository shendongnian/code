    [ServiceContract]
    public interface ISampleInterface
    {
    // No data contract is requred since both the parameter 
    // and return types are primitive types.
    [OperationContract]
    double SquareRoot(int root);
    // No Data Contract required because both parameter and return 
    // types are marked with the SerializableAttribute attribute.
    [OperationContract]
    System.Drawing.Bitmap GetPicture(System.Uri pictureUri);
    // The MyTypes.PurchaseOrder is a complex type, and thus 
    // requires a data contract.
    [OperationContract]
    bool ApprovePurchaseOrder(MyTypes.PurchaseOrder po);
