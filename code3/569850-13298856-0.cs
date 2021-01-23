    // Provide named properties which really just read elements 
    // from the List<string> provided with the constructor
    public class ListBasedRecord {
        public string SupplierName { get { return source[0]; } }
        public string SupplierCode { get { return source[1]; } }
        private List<string> source;
        public ListBasedRecord(List<string> source) { this.source = source; }
    }
    
    private void ListTest() {
        // ... same as above, you get your List<List<string>> ...
        // Succinctly create a SupplierEntryWrapper for each "record" in the source
        var wrapperList = supplierListStrings
                          .Select(x => new SupplierEntryWrapper(x)).ToList();
        dataGridView1.DataSource = wrapperList;
    }
