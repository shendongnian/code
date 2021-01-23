    List<Test> t = new List<Test>();
    using (StreamReader sr = new StreamReader("YourFilePath"))
    {
         string line = string.Empty;
         while ((line = sr.ReadLine()) != null)
         {
              string[] lines = line.Split(' ').ToArray();
              //add to your list
              t.Add(new Test() { firstName = lines[0], lastName = lines[1], dateTime = DateTime.ParseExact("MM/dd/yyyy hh:mm:ss tt", lines[2] + lines[3], CultureInfo.InvariantCulture) });
         }
    }
    //Your Ordered list now
    t = t.OrderBy(x => x.dateTime).ToList<Test>();
