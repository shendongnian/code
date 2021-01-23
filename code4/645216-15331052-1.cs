       // create anonymous objects
       var myData = File.ReadAllLines("c:\\test.txt")
           .Select(line => line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries))
           .Select(splits => new 
           {
               Date = DateTime.Parse(splits[0] + " " + splits[1]),
               Make = splits[2].Trim(),
               Year = int.Parse(splits[3].Trim()),
               Model = splits[4].Trim()
           });
       // find all "Ford" at my date
       var results = myData.Select(x => x.Date == myDate && x.Model == "Ford");
