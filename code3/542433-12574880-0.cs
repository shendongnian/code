    public partial class VendorReader
    {
        public int ID { get; set; }
        public string AssetValue { get; set; }
        public int VendorID { get; set; }
        public virtual Vendor Vendor { get; set; } 
        public int AssetReaderID { get; set; }
        public virtual AssetReader AssetReader { get; set; }
    }
