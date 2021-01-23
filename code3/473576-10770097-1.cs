    public class MainViewModel {
    
        public Partial1ViewModel Partial1 [ get; set; }
        public Partial2ViewModel Partial2 [ get; set; }
        public Partial3ViewModel Partial3 { get; set; }
        public Partial4ViewModel Partial4 { get; set; }
        public MainViewModel() {}
        public MainViewModel() {
            Partial1 = new Partial1ViewModel();
            Partial2 = new Partial2ViewModel();
            Partial3 = new Partial3ViewModel();
            Partial4 = new Partial4ViewModel();
        }
    }
