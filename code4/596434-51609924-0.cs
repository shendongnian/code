    string str = "ABCDEFG";
    Stack<char> stack=new Stack<char>();
    foreach (var c in str)
    {
        stack.Push(c);
    }
    char[] chars=new char[stack.Count];
    for (int i = 0; i < chars.Length; i++)
    {
        chars[i]=stack.Pop();
    }
    var result=new string(chars); //GFEDCBA
