    var start = new DateTime(2013, 02, 15);
    var now = DateTime.Now;
    var oneWeek = new TimeSpan(7, 0, 0, 0);
    if (now - start > oneWeek) {
        Console.Write("One week is passed since start date.");
    } else {
        Console.Write("One week not yet passed since start date.");
    }
