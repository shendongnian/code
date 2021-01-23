    public class Foo
    {
        public static List<string> list;
        public static Timer timer;
        static Foo()
        {
            list = new List<string>();
            timer = new Timer(10000);
            timer.Enabled = true;
            timer.AutoReset = false;
            timer.Elapsed += SendToServer;
        }
        public static void Log(string value)
        {
            list.Add(value);
            timer.Start();
        }
        static void SendToServer(object sender, ElapsedEventArgs e)
        {
            //TODO send data to server
            //AutoReset is false, so neither of these are needed
            //timer.Enabled = false;
            //timer.Stop();
        }
    }
