    private static void Blinker(string text, int milliseconds)
    {
        bool visible = true;
        while(true)
        {
            //Press Ctrl + C to Quit
            string alert = visible ? "ALERT! ALERT!! ALERT!!!" : "";
            visible = !visible;
            Console.Clear();
            string details = File.ReadAllText(@"C:\PersonalAssistant\RecentMeetingDetails.txt");
            Console.Write("{0}\n{1}", alert, details);
            Thread.Sleep(milliseconds);
        }
    }
