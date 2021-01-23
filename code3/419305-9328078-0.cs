    public class CustomerItemList { 
        public int ID { get; set; } 
        public string Name { get; set; } 
        public double Rate { get; set; } 
        public int Quantity { get; set; } 
        public double Total {
          get { return Rate * Quantity; }
        }
    }
