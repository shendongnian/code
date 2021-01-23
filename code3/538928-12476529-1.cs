    internal class Program
    {
        public event EventHandler CheckInvocationList;
        private static void Main(string[] args)
        {
            Program p = new Program();
            p.CheckInvocationList += new EventHandler(p_CheckInvocationList);
            p.Method1();
            Console.WriteLine(string.Join(" | ", p.CheckInvocationList.GetInvocationList().Select(d => d.Method.Name).ToArray()));
        }
        static void p_CheckInvocationList(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void Method1()
        {
            this.CheckInvocationList += new EventHandler(Program_CheckInvocationList);
        }
        void Program_CheckInvocationList(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
