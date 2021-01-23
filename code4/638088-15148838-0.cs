    var stack = new Stack<StringBuilder>();
    foreach (var ch in input)
    {
        if (ch == '{')
        {
            stack.Push(new StringBuilder());
        }
        else if (ch == '}')
        {
            var item = stack.Pop().ToString();
            Console.WriteLine(new string(' ', stack.Count * 2) + item);
        }
        else if (stack.Count != 0)
        {
            stack.Peek().Append(ch);
        }
    }
