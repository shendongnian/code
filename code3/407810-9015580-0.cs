    public class SomePropertyClass{
        public string VarA{get;set;}
        public string VarB{get;set;}
    
        public SomePropertyClass Merge (SomePropertyClass other)
        {
           return new SomePropertyClass 
                        { VarA = this.VarA ?? other.VarA, 
                          VarB = this.VarB ?? other.VarB 
                        };
        }
