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
