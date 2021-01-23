     string request = "firstname=foo+lastname=bar+amout=100.58+firstname=+lastname=bar2+amout=100.59+firstname=foo3+lastname3=bar3+amout=100.60";
            Dictionary<string, List<string>> arguments = new Dictionary<string, List<string>>();
            request.Split('+').ToList<string>().ForEach(f =>
                {
                    string[] data = f.Split('=');
                    if (data.Length == 2)
                    {
                        if (!arguments.ContainsKey(data[0]))
                        {
                            if (data[1] != "")
                                arguments.Add(data[0], new List<string> { data[1] });
                            else
                                arguments.Add(data[0], new List<string> { "no firstname" });
                        }
                        else
                        {
                            if (data[1] != "")
                                arguments[data[0]].Add(data[1]);
                            else
                                arguments[data[0]].Add("no firstname");
                        }
                    }
                });
