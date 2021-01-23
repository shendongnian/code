    class Program
    {
      static System.Threading.Timer timer = new Timer(TimerCallback, null, System.Threading.Timeout.Infinite, 0);
      static int alertX;
      static int alertY;
      static bool alertDisplayed = false;
      static int cursorX;
      static int cursorY;
      static object consoleLock = new object();
      static void Main(string[] args)
      {
         FileStream D = new FileStream("C:/PersonalAssistant/RecentMeetingDetails.txt", FileMode.Open, FileAccess.Read);
         StreamReader DR = new StreamReader(D);
         DR.BaseStream.Seek(0, SeekOrigin.Begin);
         Console.ForegroundColor = ConsoleColor.Red;
         WriteFlashingText();
         lock (consoleLock)
         {
            Console.WriteLine("\nYour Closest Appointment is on " + rd + " and has the following info");
         }
         string data = DR.ReadLine();
         while (data != null)
         {
            lock (consoleLock)
            {
               Console.WriteLine(data);
            }
            data = DR.ReadLine();
         }
         D.Close();
         DR.Close();
      }
      static void WriteFlashingText()
      {
         alertX = Console.CursorLeft;
         alertY = Console.CursorTop;
         timer.Change(0, 200);
      }
      static void TimerCallback(object state)
      {
         lock (consoleLock)
         {
            cursorX = Console.CursorLeft;
            cursorY = Console.CursorTop;
            Console.CursorLeft = alertX;
            Console.CursorTop = alertY;
            if (alertDisplayed)
            {
               Console.WriteLine("Alert! Alert! Alert!");
            }
            else
            {
               Console.WriteLine("                    ");
            }
            alertDisplayed = !alertDisplayed;
            Console.CursorLeft = cursorX;
            Console.CursorTop = cursorY;
         }
      }
    }
