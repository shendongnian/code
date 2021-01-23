        string pattern = "Hi, my name is ${name}, I am ${age} years old. I live in ${address}";
        string input = "Hi, my name is Peter, I am 22 years old. I live in San Francisco, California";
        
        string resultRegex = Regex.Replace(pattern, @"\$\{(.+?)\}", "(?<$1>.+)");
        GroupCollection groups = Regex.Match(input, resultRegex).Groups;
        foreach (string groupName in regex.GetGroupNames())
        {
            Console.WriteLine(
               "Group: {0}, Value: {1}",
               groupName,
               groups[groupName].Value);
        }
