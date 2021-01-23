    public class LinkTable
    {
        // exists in the table
        public int ItemId { get; set; }
        private Item _refItem;
        public Item RefItem
        {
            get
            {
                if (_refItem != null) { return _refItem; }
                // go get the item
            }
        }
        // exists in the table
        public int VisitId { get; set; }
        private Visit _refVisit;
        public Visit RefVisit // sample impl as above
    }
