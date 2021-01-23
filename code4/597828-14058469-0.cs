    public interface IProgress<T>
    {
        public void Report(T parameter);
    }
    
    public class Progress<T>:IProgress<T>
    {
        public event Action<T> ProgressChanged;
    
        public Progress() { }
        public Progress(Action<T> action)
        {
            ProgressChanged += action;
        }
    
        void IProgress<T>.Report(T parameter)
        {
            ProgressChanged(parameter);
        }
    }
