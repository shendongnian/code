    [Serializable]
    public class MyViewModel
    {
        public int VendorId { get; set; }
        
        [NonSerialized]
        public HttpPostedFileBase SpreadsheetFile { get; set; }       
        public IEnumerable<Vendor> Vendors { get; set; }        
    }
