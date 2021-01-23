     public class UnderlyingState implements Cancellable, Shippable ... {
        public void cancel() { ... }
        public void ship() { ... }
     }
      public class ShippableState implements Shippable {
         private UnderlyingState ustate = new UnderlyingState();
         public void cancel() {
            // you can *only* cancel this
            ustate.cancel();    
         }
       }
