    public static class Program
    {
        public static void Main(string[] arguments)
        {
            var context = new NotifyIconApplicationContext();
            context.Icon.Icon = new Icon(PATH_TO_ICON_FILE_HERE);
            context.Icon.Visible = true;    
            Application.Run(context);
        }
    }
    class NotifyIconApplicationContext : ApplicationContext
    {
        public NotifyIconApplicationContext()
        {
            Icon = new NotifyIcon();
        }
        public NotifyIcon Icon { get; set; }
    }
