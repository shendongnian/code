    public interface IBase
    {
        int customerid { get; set; }
    }
    public interface IDerived
    {
        string customerid { get; set; }
    }
    public class Derived : IBase, IDerived
    {
        int IBase.customerid { get; set; }
        string IDerived.customerid { get; set; }
    }
