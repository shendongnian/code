    class SalesPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { 
           get { return this.FirstName + " " + this.LastName; } 
        }
    }
