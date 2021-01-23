                Stopwatch sw = new Stopwatch();
                var defaultPerson = new Program.Person("Richard", 25, true);
                sw.Start();
                for(int i = 0; i < 100000000; i++)
                {
                    var myValue = myDictionary.GetValueOrDefault("Richard", defaultPerson);
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < 100000000; i++)
                {
                    var myValue = myDictionary.GetValueOrDefault("Richard", () => defaultPerson);
                }
