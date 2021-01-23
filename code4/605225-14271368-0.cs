    [Serializable]
    public class MyViewModel
    {
        public int VendorId { get; set; }
        
        [NonSerializable]
        public HttpPostedFileBase SpreadsheetFile { get; set; }       
        public IEnumerable<Vendor> Vendors { get; set; }        
    }
