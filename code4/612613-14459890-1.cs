                var output = (from c in values
                              where int.TryParse(c, out i)
                              select c).Select(s => int.Parse(s)).ToList();
                foreach (var item in output)
                {
                    Console.WriteLine(item.ToString());
                }
