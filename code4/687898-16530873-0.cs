    public class Car
    {
        // ... bunch of members for Car ...
        public static Car Open(string FileName)
        {
            Car c = new Car();
            // ... open the file and populate "c" ...
            return c;
        }
    }
