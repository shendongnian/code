    public class Base {
        public virtual void Connect() {
            // do stuff
        }
    }
    
    public class Derived1: Base {
        public override void Connect() {
            base.Connect();
            // do other stuff
        }
        public void CallBaseConnnect() {
            //here make only one call to base.Connect(). 
            //that's how class Derived1 'll provide you away to call base.Connect().
            base.Connect();
        }
    }
    
    public class Derived2: Derived {
        public override void Connect() {
            //here just make a call to CallBaseConnnect() in base class Derived1
            base.CallBaseConnnect();
        }
    }
