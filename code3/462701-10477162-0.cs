    public class Product
    {
        public Product()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    
        public string ProductName { get; set; }
        public string Property2 { get; set; }
        public string Image { get; set; }
    
        public Product(string _ProductName, string _Property2, string _Image)
        {
            this.ProductName = _ProductName;
            this.Property2 = _Property2;
            this.Image = _Image;
        }
    
        public string GetHtml
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table>");
                sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", this.ProductName, this.Property2, this.Image));
                sb.Append("<table>");
                return sb.ToString();
    
            }
            
        }
    
        
    }
