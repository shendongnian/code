    public class Tool {
        public event Action<int> ProgressChanged;
        private void OnProgressChanged(int progress) 
        {
            var eh = ProgressChanged;
            if (eh != null) {
                eh(progress);
            }
        }
        public void DoSomething()
        {
            ...
            OnProgressChanged(30);
            ...
        }
    }
