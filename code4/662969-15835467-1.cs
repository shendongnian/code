      [Fact]
            public void benchmark_dictionary() {
                var dictionary = new Dictionary<string, long> {
                    {"a", 1},
                    {"b", 2},
                    {"c", 3}
                };
    
                var dictionary2 = new Dictionary<string, Holder> {
                    {
                        "a", new Holder() {
                            Value = 1
                        }
                    }, {
                        "b", new Holder() {
                            Value = 2
                        }
                    }, {
                        "c", new Holder() {
                            Value = 3
                        }
                    }
                };
    
                var iterations = 1000000;
                var timer = new Stopwatch();
                timer.Start();
                for(int i = 0; i < iterations; i++)
                    Increment(dictionary, "a", 1);
                timer.Stop();
    
                // DumpOnConsole() -> Console.WriteLine( objetc ) 
                timer.ElapsedMilliseconds.DumpOnConsole();
    
                dictionary.DumpOnConsole();
    
                timer.Restart();
    
                for(int i = 0; i < iterations; i++)
                    Increment(dictionary2, "a", 1);
                timer.Stop();
    
                timer.ElapsedMilliseconds.DumpOnConsole();
    
                dictionary2.DumpOnConsole();
            }
