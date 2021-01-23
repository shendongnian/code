    using System.Text.RegularExpressions;
    ...
    Console.Write("Home>");
    string command = Console.ReadLine();
    Regex argReg = new Regex(@"\w+|""[\w\s]*""");
    string[] cmds = new string[argReg.Matches(command).Count];
    int i = 0;
    foreach (var enumer in argReg.Matches(command))
    {
    	cmds[i] = (string)enumer.ToString();
    	i++;
    }
