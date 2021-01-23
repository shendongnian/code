    // Super-Class
    public class Vehicle {
      // protected variable in super-class
      protected String engine = "engine";
    }
    
    // Sub-Class
    public class Car extends Vehicle {
      
      public String printEngine() {
        // Success: We can print "engine",
        // because sub-class Car extends
        // super-class Vehicle
        System.out.println(super.engine);
      }
      
      public static void main (Strings[] args) {
        Vehicle vehicle = new Vehicle();
        // Error: We can NOT print "engine",
        // because protected variable can't
        // be accessed by Vehicle instance.
        System.out.println(vehicle.engine);
      }
    }
