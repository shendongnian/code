    static void Main(string[] args)
    {
        try
        {
            try
            {
                try
                {
                    Foo();
                }
                catch (Exception ex1)
                {
                    Console.WriteLine(ex1.ToString());
                    throw;
                }
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.ToString()); // expected same stack trace
                throw ex2;
            }
        }
        catch (Exception ex3)
        {
            Console.WriteLine(ex3.ToString());
        }
    }
    static void Foo()
    {
        throw new Exception("Test2");
    }
