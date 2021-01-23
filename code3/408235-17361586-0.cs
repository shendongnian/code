    public class Product
    {
        private NameValueCollection collection = new NameValueCollection();
        public string Company { get; set; }
        public string Distributor { get; set; }
        public int ID { get; set; }
        ...
        public string this[string index]
        {
            get { return collection[index]; }
            set { if(!string.IsNullOrEmpty(value)) collection[index]=value; }
        }
    }
