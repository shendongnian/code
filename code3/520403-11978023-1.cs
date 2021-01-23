    public class A
    {
        private MyClass my = new MyClass();
    
        public void Do()
        {
            TryToChangeInstance(my);
            DoChangeInstance(my);
            DoChangeProperty(my);
        }
      
        private void TryToChangeInstance(MyClass my)
        {
            // The copy of the reference is replaced with a new reference.
            // The instance assigned to my goes out of scope when the method exits.
            // The original instance is unaffected.
            my = new MyClass(); 
        }
      
        private void DoChangeInstance(ref MyClass my)
        {
            // A reference to the reference was passed in
            // The original instance is replaced by the new instance.
            my = new MyClass(); 
        }
      
        private void DoChangeProperty(MyClass my)
        {
            my.SomeProperty = 42; // This change survives the method exit.
        }
    }
