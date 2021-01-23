    var listTimes = doc.Elements("Reminders").Elements("Reminder").Select(s => s.Element("Time"));
    
    foreach (var item in listTimes)
    {
        Console.Write(DateTime.Parse(item.Value, CultureInfo.InvariantCulture));
    }
