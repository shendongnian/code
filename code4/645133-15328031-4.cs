    sw = new System.Diagnostics.Stopwatch();
    // Number 1
    bool value = true;
    int channel = 1;
    sw.Start();
    for (int i = 0; i <= 100000; i++)
    {
        String s = String.Format(":Channel{0}:Display {1}", channel, value ? "ON" : "OFF");
    }
    sw.Stop();
    sw.Reset();
    // Number 2
    sw.Start();
    for (int i = 0; i <= 100000; i++)
    {
        string s = "Channel" + channel + ":Display " + (value ? "ON" : "OFF");
    }
    sw.Stop();
