    public class Asset
    {
        public int AssetTrackingID { get; set; }
        public Category AssetCategoryInfo { get; set; }
        public Manufacturer AssetManufacturerInfo { get; set; }
        public ManufacturerModel AssetModelInfo { get; set; }
        public Status AssetStatusInfo { get; set; }
        public EmployeeDetails AssetEmployeeInfo { get; set; }
        public string AssetNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? AcquiredDate { get; set; }
}
