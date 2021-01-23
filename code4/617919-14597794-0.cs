    public class ViewModel
    {
        public ViewModel()
        {
            Segments = new ViewModelSegments();
            SomethingElse = new ViewModelSomethingElse();
        }
    
        public ViewModelSegments Segments { get; set; }
        public ViewModelSomethingElse SomethingElse { get; set; }
    }
