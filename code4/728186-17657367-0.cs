    static int i = 0;
    static void Main(string[] args)
    {
        while (Console.ReadLine() == "")
        {
    
            var pageSB = new StringBuilder();
    
            foreach (var section in new[] { AddHeader(), AddContent(), AddFooter() })
                for (int i = 0; i < section.Length; i++)
                    pageSB.Append(section[i]);
    
            Console.Write(pageSB.ToString());
        }
    
    }
    
    static StringBuilder AddHeader()
    {
        return new StringBuilder().Append("Hi ").AppendLine("World");
    }
    
    static StringBuilder AddContent()
    {
        return new StringBuilder()
            .AppendFormat("This page has been viewed: {0} times\n", ++i);
    }
    
    static StringBuilder AddFooter()
    {
        return new StringBuilder().Append("Bye ").AppendLine("World");
    }
