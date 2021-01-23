    namepsace A {
        public class NotRelatedA() {
           public void Run() {}
        }
    }
    
    namepsace B {
        public class NotRelatedB() {
           public void Run() {}
        }
    }
    dynamic dyn = new A.NotRelatedA();
    dyn.Run(); //Run A
    
    dyn = new B.NotRelatedB();
    dyn.Run(); //Run B, without changing and mapping anything
