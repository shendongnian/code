    var list = new List<Name>();
    list.Add(new Name { First = "Brian",   Middle = "D", Last = "Gideon" });
    list.Add(new Name { First = "Bart",    Middle = "",  Last = "Simpson" });
    list.Add(new Name { First = "Captain", Middle = "",  Last = "America" });
    var ordered = list.OrderBy(x => x.Last).ThenBy(x => x.First).ThenBy(x => x.Middle);
    foreach (Name item in ordered)
    {
      Console.WriteLine(item.Last + ", " + item.First + " " + item.Middle);
    }
