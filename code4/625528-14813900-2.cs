       public class ShippableState implements Shippable {
          private UnderlyingState ustate = new UnderlyingState();
          public void cancel() {
             // you can *only* cancel this
             ustate.cancel();
          }
        }
