    // This is just to help with some reflection stuff
    public interface IViewModelParams { }
    public interface IViewModelParams<T> : IViewModelParams        
    {
        // It contains a single method which will pass arguments to the viewmodel after the nav service has instantiated it from the container
        void ProcessParameters(T modelParams);
    }
