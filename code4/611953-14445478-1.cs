    interface ILastModified {
    {
        DateTime LastModified { get; set; }
    }
    public partial class Product : ILastModified
    {
      public DateTime LastModified { get; set; }
    }
