    var dict = new Dictionary<string,int>();
    dict.Add("Sunday", 1);
    dict.Add("Monday", 2);
    dict.Add("Tuesday", 3);
    dict.Add("Wednesday", 4);
    dict.Add("Thursday", 5);
    dict.Add("Friday", 6);
    dict.Add("Saturday", 7);
    
    Console.WriteLine(dict["Wednesday"]); // ==> 4
    
    int daynum;
    if (dict.TryGetValue("Christmas", out daynum)) {
        Console.WriteLine("Christmas has the day number {0}.", daynum);
    } else {
        Console.WriteLine("Christmas is not a weekday.");
    }
