    public class fooHub : Hub
    {
        public void DisplayTimeOnServer()
        {
            Console.WriteLine(DateTime.Now.ToString());
        }
    }
