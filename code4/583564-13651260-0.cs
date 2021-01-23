    string input = @"( 8 5 + ) 6 *";
    var tokens = Regex.Matches(input, @"(?<num>[0-9]+)|(?<op>[\+\-\*\/\^\%])").Cast<Match>()
                    .Select(m=> String.IsNullOrEmpty(m.Groups["num"].Value)
                                ? new Tuple<string,string>("op",m.Groups["op"].Value)
                                : new Tuple<string,string>("num",m.Groups["num"].Value))
                    .ToList();
    var fxns = new Dictionary<string, Func<int, int, int>>()
    {
        {"+",(i,j)=>i+j },
        {"-",(i,j)=>i-j },
        {"*",(i,j)=>i*j },
        {"/",(i,j)=>i/j },
        {"%",(i,j)=>i%j },
        {"^",(i,j)=>(int)Math.Pow(i,j) },
    };
    Stack<int> stack = new Stack<int>();
    foreach (var token in tokens)
    {
        if (token.Item1 == "num")
        {
            stack.Push(int.Parse(token.Item2));
        }
        if (token.Item1 == "op")
        {
            stack.Push(fxns[token.Item2](stack.Pop(), stack.Pop()));
        }
    }
    int finalResult = stack.Pop();
