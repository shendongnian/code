    bool visible = true;
    do
    {
        //Press Ctrl + C to Quit
        string alert = visible ? "ALERT! ALERT!! ALERT!!!" : "";
        visible = !visible;
        Console.Clear();
        string details = File.ReadAllText(@"C:\PersonalAssistant\RecentMeetingDetails.txt");
        Console.ForegroundColor = visible? ConsoleColor.Red : ConsoleColor.White;
        Console.WriteLine(alert);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(details);
        Thread.Sleep(100);
    } while (true);
