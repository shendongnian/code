        string pattern = "Hi, my name is ${name}, I am ${age} years old. I live in ${address}";
        string input = "Hi, my name is Peter, I am 22 years old. I live in San Francisco, California";
        string resultRegex = Regex.Replace(Regex.Escape(pattern), @"\\\$\\\{(.+?)}", "(?<$1>.+)");
        Regex regex = new Regex(resultRegex);
        GroupCollection groups = regex.Match(input).Groups;
        Dictionary<string, string> dic = regex.GetGroupNames()
                                              .Skip(1)
                                              .ToDictionary(k => "${"+k+"}",
                                                            k => groups[k].Value);
        foreach (string groupName in dic.Keys)
        {
            Console.WriteLine(groupName + " = " + dic[groupName]);
        }
