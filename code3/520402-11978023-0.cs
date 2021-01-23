    public class A
    {
        private MyClass my = new MyClass();
    
        public void Do()
        {
            TryToChangeInstance(my);
            DoChangeProperty(my);
        }
      
        private void TryToChangeInstance(MyClass my)
        {
            // The copy of the address is replaced with a new address.
            // The instance assigned to my goes out of scope when the method exits.
            // The original instance is unaffected.
            my = new MyClass(); 
        }
      
        private void DoChangeProperty(MyClass my)
        {
            my.SomeProperty = 42; // This change survives the method exit.
        }
    }
