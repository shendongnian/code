    static void Main(string[] args)
    {
        while(true){
            IrcClient bot = new IrcClient();
            // attach events
            try
            {
                // connect to server, login etc
                // here we tell the IRC API to go into a receive mode, all events
                // will be triggered by _this_ thread (main thread in this case)
                // Listen() blocks by default, you can also use ListenOnce() if you
                // need that does one IRC operation and then returns, so you need then
                // an own loop
                bot.Listen();
                // disconnect when Listen() returns our IRC session is over
                bot.Disconnect();
            }
            catch (ConnectionException e)
            {
                Console.WriteLine("Couldn't connect! Reason: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(">> Error: " + e);
            }
        }
    }
