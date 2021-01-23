    public class MyWindow
    {
        public event OpenEventHandler Open;
        public void OpenWindow()
        {
            if (Open != null)
            {
                Open(this, new EventArgs());
            }
        }
        public Delegate[] getHandlers()
        {
            return Open.GetInvocationList();
        }
    }
    public class TwoDelegates
    {
        public static void HandleOpen(Object sender, EventArgs e)
        {
            Console.WriteLine("Birds fly");
            var thisWin = sender as MyWindow;
            var before = thisWin.getHandlers();
            
            (sender as MyWindow).Open -= HandleOpen;
            var after = thisWin.getHandlers();
        }
        public static void Run()
        {
            var window = new MyWindow();
            window.Open += HandleOpen;
            window.Open += HandleOpen;
            window.OpenWindow();
            Console.ReadKey();
        }
    }
