    public class Other
    {
        public static void CloseHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Closed");
        }
        
        public static void Main(string[] args)
        {
            Form1 form = new Form1();
            form.OnClose += CloseHandler;
            form.OnClick += (s,e) => Console.WriteLine("Click");
        }
    }
