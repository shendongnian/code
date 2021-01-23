    public static class TimerEventsInitializations
    {
        public static void InitializeWeatherReader()
        {
            Timer t = new Timer(1000);
            t.Elapsed += new EventHandler(MyEventHandler);
            t.Start();
        }
        public static void MyEventHandler()
        {
           YahooWeatherManager.GetYahooWeatherRssItem("", "http://xml.weather.yahoo.com/ns/rss/1.0")
        }
    }
