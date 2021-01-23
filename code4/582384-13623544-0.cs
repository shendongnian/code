    class Program
    {
        static void Main()
        {
            int n = 3;
            for (int i = 1; i < n; i++)
            {
                string from = "C:\\vid\\(" + i + ").PNG";
                string to = "C:\\ConvertedFiles\\" + i + ".png";
                {
                    try
                    {
                        File.Move(from, to); // Try to move
                        Console.WriteLine("Moved"); // Success
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        Console.WriteLine(e); // Write error
                    }
                }
            }
        }
    }
