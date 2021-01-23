    string[] lines = File.ReadAllLines(path);
    int index = 0;
    while (index < lines.Length)
    {
        Event special = new Event();
        special.Day = Convert.ToInt32(lines[index]);
        special.Time = Convert.ToDateTime(lines[index + 1]);
        special.Price = Convert.ToDouble(lines[index + 2]);
        special.StrEvent = lines[index + 3];
        special.Description = lines[index + 4];
        events.Add(special);
        lines = lines + 5;
    }
