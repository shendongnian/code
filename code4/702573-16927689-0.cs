    private static void Main()
            {
                int[] c={1};
                String s="this is a false integer";
                try
                {
                    int z = 0;
                    int x = 5/z;
                }
                catch (ArithmeticException exception)
                {
                    Console.WriteLine(exception.GetType().ToString());
                }
                finally
                {
                    try
                    {
                        c[10] = 12;
                    }
                    catch(IndexOutOfRangeException exception)
                    {
                        Console.WriteLine(exception.GetType().ToString());
                    }
                    finally
                    {
                        try
                        {
                            int y = int.Parse(s);
                        }
                        catch (FormatException exception)
                        {
                            Console.WriteLine(exception.GetType().ToString());
                        }
                    }
    
                    Console.ReadKey();
                }
            } 
