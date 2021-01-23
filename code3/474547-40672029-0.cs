    Static classes don't require you to create an object of that class/instantiate them, you can prefix the C# keyword static in front of the class name, to make it static.
    
    Remember? we're not instantiating the Console class, String class, Array Class.
    
    class Book
    {
        public static int myInt = 0;
    }
    
    public class Exercise
    {
        static void Main()
        {
            Book book = new Book();
           //Use the class name directly to call the property myInt, 
          //don't use the object to access the value of property myInt
    
            Console.WriteLine(Book.myInt);
    
            Console.ReadKey();
    
        }
    }
                
    So yeah, that's that
