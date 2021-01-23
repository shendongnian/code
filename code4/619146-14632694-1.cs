    public class Foo
    {
      static void Main(string[] args)
      {
         var domain = AppDomain.CurrentDomain;
         domain.FirstChanceException += new EventHandler<FirstChanceExceptionEventArgs>(CurrentDomain_FirstChanceException);
      }
       static void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs args)
        {
           //If you are not putting this inside a try finally block then this would become an infinite recursion.
            try
            {
                var actualException = args.Exception;
                Console.WriteLine(actualException.ToString());
                //Do whatever with actualException
            }
            finally
            {
            }
        }
    }
