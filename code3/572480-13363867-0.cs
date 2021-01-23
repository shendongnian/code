    class ItemWithDetails {
        public string Size;
        public List<KeyValuePair<string, double>> Details { get; private set; }
 
        public ItemWithDetails() {
		  Details=new List<KeyValuePair<string,double>>();
       }
    }
