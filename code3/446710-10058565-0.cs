    String[] tests = {
        "preferences = 'Hello my name is Paul. I hate puzzles.'",
        "preferences = 'Salutations my name is Richard. I love pizza. I hate rain.'",
        "preferences = 'Hi my name is Bob. Regex turns me on.'"};
    var re1 = new Regex("preferences = '(.*)'");
    var re2 = new Regex("([^\\.]+(?<=.*\\bhate\\b.*)).\\s*");
    for (int i=0; i < tests.Length; i++)
    {
        Console.WriteLine("{0}: {1}", i, tests[i]);
        var m = re1.Match(tests[i]);
        if (m.Success)
        {
            var s = m.Groups[1].ToString();
            s = re2.Replace(s,"");
            Console.WriteLine("   {1}", i, s);
        }
        Console.WriteLine();
    }
