    public abstract class Repository {
        public Respository(ObjectContext context){
            CurrentContext = context;
        }
        protected ObjectContext CurrentContext { get; private set; } 
    }
    public class ProductRespository : Repository {
        public ProductRespository(ObjectContext context) : base(context){
        }
  
        public Product GetXXXXXX(...){
            return CurrentContext... ; //Do something with the context
        }
    }    
