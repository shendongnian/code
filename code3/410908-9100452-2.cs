    // Here you declare your DoSomething class
    public class DoSomething
    {
        // now you're defining a static function called Main
        // This function isn't associated with any specific instance
        // of your class. You can invoke it just from the type,
        // like: DoSomething.Main(...)
        public static void Main(System.String[] args)
        {
            // Here, you declare some variables that are only in scope
            // during the Main function, and assign them values 
            System.String apple = args[0];
            System.String orange = args[1];
            System.String banana = args[2];
            System.String peach = args[3];
        }
            // at this point, the fruit variables are all out of scope - they
            // aren't members of your class, just variables in this function.
        // There are no variables out here in your class definition
        // There isn't a constructor for your class, so only the
        // default public one is available: DoSomething()
    }
