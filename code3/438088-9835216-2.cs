    static void DisplaySlots(string format, Period slotLength, int slots)
    {
        // Or change the parameter to be a LocalTimePattern
        LocalTimePattern pattern = LocalTimePattern.CreateWithInvariantInfo(format);
        LocalTime time = LocalTime.Midnight;
        for (int i = 0; i < slots; i++)
        {
            Console.WriteLine(pattern.Format(time));
            time = time + slotLength;
        }
    }
