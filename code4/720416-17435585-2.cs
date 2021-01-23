    public class YourCoolService
    {
        public void DoSomething(ISomeDataBlob blob)
        {
            if (blob.GetType().Assembly != Assembly.GetExecutingAssembly())
                throw new InvalidOperationException("We only support our own types");
        }
    }
