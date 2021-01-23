    public class Document
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
    public class OrderLinesDocument : Document
    {
        public ICollection<OrderLine> OrderLines { get; set; }
    }
    public interface IVendorDocument
    {
        ICollection<Vendor> Vendors { get; set; }
    }
    public class VendorDocument : Document, IVendorDocument
    {
        public ICollection<Vendor> Vendors { get; set; }
    }
    public interface ICustomerDocument
    {
        ICollection<Customer> Customers { get; set; }
    }
    public class CustomerDocument : Document
    {
        public ICollection<Customer> Customers { get; set; }
    }
    public class PurchaseOrder : OrderLinesDocument, IVendorDocument
    {
        public ICollection<Vendor> Vendors { get; set; }
    }
    public class Invoice : Document, ICustomerDocument
    {
        public ICollection<Customer> Customers { get; set; }
    }
