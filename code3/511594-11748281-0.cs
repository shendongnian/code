    public class WidgetOptions
    {
        public string Server { get; set; }
        public string Port { get; set; }
        ... 
    }
    public class MyWidget
    {
        public MyWidget(WidgetOptions options)
        {
             Server = options.Server;
             Port = options.Port;
             ...
        }
    }
