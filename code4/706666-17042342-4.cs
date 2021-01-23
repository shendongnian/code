    bool visible = true;
    do
    {
        //Press Ctrl + C to Quit
        string alert = "ALERT! ALERT!! ALERT!!!";
        Console.ForegroundColor = visible ? ConsoleColor.Red : ConsoleColor.White;
        visible = !visible;
        Console.Clear();
        string details = @"C:\PersonalAssistant\RecentMeetingDetails.txt";
        Console.WriteLine(alert);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(details);
        Thread.Sleep(100);
    } while (true);
