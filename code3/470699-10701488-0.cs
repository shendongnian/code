    public class Item {
        public Guid ThreadRoot { get; set; }
        public Item() {
            ThreadRoot = Guid.Empty; //default value
        }
     }
