            if (a.Length == d.Length)
            {
                var result = a.Except(d).ToArray();
                if (result.Count() == 0)
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            else
            {
                Console.WriteLine("NO");
            }
