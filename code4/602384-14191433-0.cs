    class Program
    {
        static Label a;
        static void Main(string[] args)
        {
            var t = new Thread(ExecuteForm);
            t.Start();
            lol();
        }
        static void lol()
        {
            var s = Console.ReadLine();
            a.Invoke(new Action(() => a.Text = s));
            lol();
        }
        public static void ExecuteForm()
        {
            var abc = new Form();
            a = new Label();
            a.Text = "nothing";
            abc.Controls.Add(a);
            Application.Run(abc);
        }
    }
