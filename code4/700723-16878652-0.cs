    public interface IHandler
    {
        void Handle();
    }
    public class HandlerDirector
    {
        IList<IHandler> Handlers = new List<IHandler>();
        public void AddHandler(IHandler handler)
        {
            Handlers.Add(handler);
        }
        public void RunAllHandlers()
        {
            foreach (IHandler handler in Handlers)
                handler.Handle();
        }
    }
