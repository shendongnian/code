    public class DisposableBucket : IDisposable
    {
        readonly List<IDisposable> listOfDisposables = new List<IDisposable>();
        public TClass Using<TClass>(TClass disposable) where TClass : IDisposable
        {
            listOfDisposables.Add(disposable);
            return disposable;
        }
        public void Dispose()
        {
            foreach (var listOfDisposable in listOfDisposables)
            {
                listOfDisposable.Dispose();
            }
        }
    }
