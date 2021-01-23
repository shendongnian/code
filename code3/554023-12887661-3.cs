    string a = Console.ReadKey().KeyChar.ToString();     // add KeyChar
    Expression e = new Expression("2 + [a] * 5"); 
    e.Parameters["a"] = a;                               // don't forget this line
    object x = e.Evaluate();
    Console.WriteLine("{0}", x.ToString());
    Console.ReadKey();
