    public class ProductComparer{
        public virtual void TrackChange(Product p1, Product p2, ref PChange change){
            if(p1.Name != p2.Name){
                change.NameChange = true;
            }
            // other base validation
        }
    }
    
    public class AdvancedProductComparer : ProductComparer{
        public AdvancedProductComparer(ProductComparer baseComparer){
            this.baseComparer = baseComparer;
        }
        ProductComparer baseComparer;
    
        public override void TrackChange(Product p1, Product p2, ref PChange change){
            baseComparer.Compare(p1, p2, ref change);
            if(p1.CurrentVersion != p2.CurrentVersion){
                change.CurrentVersion = true;
            }
        }
    }
    public class ProductComparerService{
        public ProductComparerService(ProductComparer comparer){
            this.comparer = comparer;
        }
        ProductComparer comparer;
        private PChanges change;
        public PChanges Changes{ get { return change; } }
    
        public bool Equals(Product p1, Product p2){
            PChanges newChange = new PChanges();
            comparer.Compare(p1,p2, ref newChange);            
            
            this.change = newChange;
            return (newChange.CurrentVersion || newChange.NameChange);
        }
     }
