    List<Tuple<string, string, DateTime>> myList = new List<Tuple<string,string,DateTime>>();
    myList.Add(new Tuple<string, string, DateTime>("Bob", "Programmer", new DateTime(2013,6,20)));
    myList.Add(new Tuple<string, string, DateTime>("Stan", "Programmer", new DateTime(2013, 6, 25)));
    myList.Add(new Tuple<string, string, DateTime>("Curly", "Athlete", new DateTime(2013, 6, 20)));
    var result = myList.AsEnumerable().Where(x => x.Item2.Equals("Programmer")).OrderByDescending(x => x.Item3).Take(1);
