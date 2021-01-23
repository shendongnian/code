    bool visible = true;
    do
    {
        //Press Ctrl + C to Quit
        string alert = visible ? "ALERT! ALERT!! ALERT!!!" : "";
        visible = !visible;
        Console.Clear();
        string details = File.ReadAllText(@"C:\PersonalAssistant\RecentMeetingDetails.txt);
        Console.Write("{0}\n{1}", alert, details);
        Thread.Sleep(100);
    } while (true);
