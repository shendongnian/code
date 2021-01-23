                string[] values = { "1", "2", "3a", "4" };
                int i = int.MinValue;
                var output = (from a in values
                              where int.TryParse(a, out i)
                              select a).ToList();
                foreach (var item in output)
                {
                    Console.WriteLine(item.ToString());
                }
