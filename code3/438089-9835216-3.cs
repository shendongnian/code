    static void DisplaySlots(string format, TimeSpan slotLength, int slots)
    {
        DateTime time = DateTime.Today;
        for (int i = 0; i < slots; i++)
        {
            Console.WriteLine(time.ToString(format));
            time = time + slotLength;
        }
    }
