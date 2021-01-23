    List<object> myList = new List<object>();
    myList.Add(new Months());
    myList.Add(new OtherClassWithoutJan());
    string monthName = "Jan";
    var withJan = myList.Where(x => x.GetType().GetProperties().Select(p => p.Name).ToList().Contains(monthName)).ToList();
