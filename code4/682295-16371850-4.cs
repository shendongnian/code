    public class ProductComparer : IEqualityComparer<Product>{
        private PChanges change;
        public PChanges Changes{ get { return change; } }
    
        public bool Equals(Product p1, Product p2){
            PChanges newChange = new PChanges();
            bool equal = true;
            if(p1.Name != p2.Name){
                newChange.NameChange = true;
                equal = false;
            }
            this.change = newChange;
            return equal;
        }
    }
