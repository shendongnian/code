    public abstract class Device : Common, IDisposable
    {
        protected Device(List<Parameters> activeParameters)
        {
            ActiveParameters = activeParameters;
        }
        protected List<Parameters> ActiveParameters { get; private set; }
    }
