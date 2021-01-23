    public class Car {
        public String Color { get; set; }
    }
    
    Car A = new Car { Color = "Red" };
    Car B = A;
    B.Color = "Blue";
    Console.WriteLine(A.Color); // Prints "Blue"
    // What you are doing with the strings in your example is the equivalent of:
    Car C = A;
    C = new Car { Color = "Black" };
