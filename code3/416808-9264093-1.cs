    Regex re = new Regex(@"(?<prop1>pattern part 1)(?<prop2>pattern part 2)");
    var goodLines = 
        from line in File.ReadAllLines(inputFile)
        let m = re.Match(line)
        where m.Success
        select new {
            Prop1 = m.Groups["prop1"].ToString(),
            Prop2 = m.Groups["prop2"].ToString()
        }
    foreach (var goodLine in goodLines) {
        DoSomething(goodLine);
    }
