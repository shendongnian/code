    public class AbortableParameter<T>
    {
        public T Parameter { get; private set }
        public bool ShouldAbort { get; set; }
        public AbortableParameter(T parameter)
        {
            Parameter = parameter;
            ShouldAbort = false;
        }
    }
