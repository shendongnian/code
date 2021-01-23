       var allStrings = new  List<string>{"stringOne", "stringOne", "stringTwo", "stringOne", "stringThree", "stringTwo"};
       var allStringsGrouped = allStrings.GroupBy(i => i);
       foreach (var group in allStringsGrouped)
       {
           System.Diagnostics.Debug.WriteLine(group.Key +" occured " + group.Count() + " times");
       }
