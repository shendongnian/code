    public class Project
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Vendor> Vendors { get; set; }
        public virtual IList<VendorPayment> VendorPayments { get; set; }
    }
    public class Vendor
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
    public class VendorPayment
    {
        public virtual int Id { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual float Amount { get; set; }
    }
