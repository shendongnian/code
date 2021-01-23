            for (int i = 0; i < 100000; i++)
            {
                if (i.ToString() != ConvertToString(i))
                {
                    Console.WriteLine(i);
                    ConvertToString(i);
                }
            }
