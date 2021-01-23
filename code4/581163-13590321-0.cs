    abstract class abstractBaseClass {
        public abstract abstractBaseClass(object argument);
        public abstract abstractBaseClass CreateMe();
    }
    
    
    class baseClass : abstractBaseClass
    {
       ...
       public override abstractBaseClass CreateMe(){
          return new baseClass();
       }
    }
