    public ProjectMappings : ClassMap<Project>
    {
        public ProjectMappings()
        {
            Table("Projects");
            Id(x => x.Id).Column("Project_Id");
            HasManyToMany(x => x.Vendors).Table("Project_Vendors")
                .ParentKeyColumn("Project_Id")
                .ChildKeyColumn("Vendor_Id")
                .Cascade.AllDeleteOrphan();
            HasMany(x => x.VendorPayments).Table("Project_Vendor_Payments")
                .KeyColumn("Project_Id")
                .Cascade.AllDeleteOrphan();
            Map(x => x.Name).Column("Project_Name")
        }
    }
    public class VendorMappings : ClassMap<Vendor>
    {
        public VendorMappings()
        {
            Table("FMS_Vendors");
            Id(x => x.Id).Column("Vendor_Id");
            Map(x => x.Name).Column("Vendor_Name");
        }
    }
    public class VendorPaymentMappings : ClassMap<VendorPayment>
    {
        public VendorPaymentMappings()
        {
            Table("Project_Vendor_Payments");
            Id(x => x.Id).Column("Payment_Id");
            References(x => x.Vendor).Column("Vendor_Id");
            Map(x => x.Amount).Column("Payment_Amount");
        }
    }
