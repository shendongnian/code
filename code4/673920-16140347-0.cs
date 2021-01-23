    string[] lines = File.ReadAllLines(path);
    
    for (int index = 4; index < lines.Length; index += 5)
    {
        Event special = new Event();
        special.Day = Convert.ToInt32(lines[index - 4]);
        special.Time = Convert.ToDateTime(lines[index - 3]);
        special.Price = Convert.ToDouble(lines[index - 2]);
        special.StrEvent = lines[index - 1];
        special.Description = lines[index];
        events.Add(special);
    }
