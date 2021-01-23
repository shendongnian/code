    // Super-Class: Vehicle
    public class Vehicle {
      // (1) I'm a protected variable
      protected String engine = "engine";
    }
    
    // Sub-Class: Car
    public class Car extends Vehicle {
      public String printEngineSuccess() {
        // (2) We can print a protected variable,
        // from within this class because it extends
        // the super-class `Vehicle`.
        System.out.println(super.engine); // --> SUCCESS
      }
      public String printEngineError() {
        // (3) We can NOT print a protected variable,
        // from a `new` instance of the super-class `Vehicle`.
        Vehicle vehicle = new Vehicle();
        System.out.println(vehicle.engine); // --> ERROR
      }
      public static void main (Strings[] args) {
        printEngineSuccess();
        printEngineError();
      }
    }
