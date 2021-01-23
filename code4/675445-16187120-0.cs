    var fileName = CSVFileName + ".csv";
    var writer = new StreamWriter(fileName);
    foreach (var items in profiles.Values)
    {
        writer.WriteLine(/*header goes here, if needed*/);
        foreach(var item in items)
        {
            writer.WriteLine(item.property1 +"," +item.propery2...);
        }
    }
    writer.Close();
