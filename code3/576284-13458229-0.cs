    class Program
    {
        static void Main(string[] args)
        {
           if (args != null)
           {
             String filePath = args[0];
             SomeForm frm = new SomeForm(filePath );
           }
        }
    }
