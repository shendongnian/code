    public static List<string> logme = new List<string>();
    // Launch LogLoop as a thread!
    public static void logloop()
    {
         while (true)
         {
              while (logme.Count > 0)
              {
                  File.AppendAllText("log.txt", logme[0] + "\r\n");
                  logme.RemoveAt(0);
              }
              Thread.Sleep(500);
         }
    }
    // Oh, and whenever you want to log something, just do:
    logme.add("Log this text!");
