    string input = "1,2,3,4,5,6,7,8,9,10,11,12";
    //string input = File.ReadAllText(/*p*/"C:/Test.txt");
    List<List<string>> all = input.Split(',')
                            .Select((s, i) => new { s, i })
                            .GroupBy(x => x.i / 3)
                            .Select(g => g.Select(x=>x.s).ToList())
                            .ToList();
    foreach(var bits in all)
    {
        Console.WriteLine("{0} {1} {2}", bits[0], bits[1], bits[2]);
        //dataPoint a = new dataPoint(bits[0], bits[1], bits[2]);
        //Points.Add(a); 
    }
