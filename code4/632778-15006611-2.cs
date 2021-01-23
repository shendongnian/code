    public class Parent
    {
    
         public string Id {get; set;}
    
         public virtual void InitPorperties() {
            //init properties of base
         }
    
    }
    
    
    public class Child : Base {
    
        public override void InitProperties() {
            //init Child properties
            base.InitProperties();
        }
    }
