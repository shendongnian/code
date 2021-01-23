    interface ILastModified {
    {
        DateTime LastModified { get; set; }
    }
    public partial class Product : ILastModified
    {
        /* this prop is declared in the Ef generated class   */
        //public DateTime LastModified { get; set; }
    }
