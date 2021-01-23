    public class ViewModel
    {
        public ViewModel(Service service)
        {
            service.GetResults().Subscribe(x => Results.Add(x));
        }
        public ObservableCollection<Result> Results { get; set; }
    }
