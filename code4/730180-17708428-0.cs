    int theTWAValue;
    string text = "95";
    if (text != null && int.TryParse(text, out theTWAValue) && theTWAValue >= 0)
    {
        Console.WriteLine((theTWAValue < 90) ? "System.Drawing.Color.Yellow" : "System.Drawing.Color.Red");
    }
