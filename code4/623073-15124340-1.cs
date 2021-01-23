    static void Main(string[] args)
    {
        string currentParameter = "";
        Dictionary<string, List<string>> parameters = new Dictionary<string, List<string>>();
        OptionSet set = new OptionSet() {
                { "c", ".c files", v => currentParameter = "c" },
                { "j", ".j files", v => currentParameter = "j" },
                { "<>", v => {
                        List<string> values;
                        if (parameters.TryGetValue(currentParameter, out values))
                        {
                            values.Add(v);
                        }
                        else
                        {
                            values = new List<string> { v };
                            parameters.Add(currentParameter, values);
                        }
                    }
                }
            };
        set.Parse(args);
        foreach (var parameter in parameters)
        {
            Console.WriteLine("Parameter: {0}", parameter.Key);
            foreach (var value in parameter.Value)
            {
                Console.WriteLine("\t{0}", value);
            }
        }
    }
