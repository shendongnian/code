    public class BadEventPublisher
    {
        public event EventHandler Evil
        {
            add { Console.WriteLine("Mwahahaha!"); }
            remove { }
        }
        protected virtual void OnEvil(EventArgs e)
        {
            Console.WriteLine("Who cares? Subscriptions are ignored!");
        }
    }
