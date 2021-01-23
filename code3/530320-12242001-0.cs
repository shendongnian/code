    class Boy
{
     public void hello()
        {
            Console.WriteLine("Hello!");
        }
        static void Main(String[] args)
        {
            Boy a = new Boy();
            a.hello();
            Type objtype = a.GetType();
            Console.WriteLine(objtype.Name); // this will display "Boy"
        }
