        static void Main(string[] args)
        {
            int lines = 5;
            for (int i = 0; i < lines; i++)
            {
                bool flag = false;
                for (int j = 0; j < lines; j++)
                {
                    if (j == i)
                    {
                        Console.WriteLine("**");
                        flag = true;
                    }
                    else
                    {
                        if (!flag)
                            Console.Write(" ");
                    }
                }
            }
        }
