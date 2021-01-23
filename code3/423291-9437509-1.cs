    class Test {
        struct Queue2Element {
            public string CPF;
            public List<string> Years;
            public string XML;
        }
        public static void Main() {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var queue1 = new BlockingCollection<string>();
            var task1 = new Task(
                () => {
                    foreach (var line in File.ReadLines("input.txt"))
                        queue1.Add(line);
                    queue1.CompleteAdding();
                }
            );
            var queue2 = new BlockingCollection<Queue2Element>();
            var task2 = new Task(
                () => {
                    foreach (var line in queue1.GetConsumingEnumerable())
                        queue2.Add(
                            new Queue2Element {
                                CPF = ParseCpf(line),
                                XML = ParseXml(line),
                                Years = ParseYears(line).ToList()
                            }
                        );
                    queue2.CompleteAdding();
                }
            );
            var task3 = new Task(
                () => {
                    var lines = 
                        from element in queue2.GetConsumingEnumerable()
                        from year in element.Years
                        select element.CPF + year + element.XML;
                    File.WriteAllLines("output.txt", lines);
                }
            );
            task1.Start();
            task2.Start();
            task3.Start();
            Task.WaitAll(task1, task2, task3);
            stopwatch.Stop();
            Console.WriteLine("Completed in {0}ms", stopwatch.ElapsedMilliseconds);
        }
        // Returns the CPF, in the form "CPF=xxxxxx;"
        static string ParseCpf(string line) {
            int start = line.IndexOf("CPF=");
            int end = line.IndexOf(";", start);
            // TODO: Validation
            return line.Substring(start, end + 1 - start);
        }
        // Returns a sequence of year values, in the form "YEAR=2010;"
        static IEnumerable<string> ParseYears(string line) {
            // First year.
            int start = line.IndexOf("YEARS=") + 6;
            int end = line.IndexOf(" ", start);
            // TODO: Validation
            string years = line.Substring(start, end - start);
            foreach (string year in years.Split(';')) {
                yield return "YEARS=" + year + ";";
            }
        }
        // Returns all the XML from the leading space onwards
        static string ParseXml(string line) {
            int start = line.IndexOf(" <?xml");
            // TODO: Validation
            return line.Substring(start);
        }
    }
