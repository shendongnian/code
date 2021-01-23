    public class OtherMainViewModel {
    
        public Partial2ViewModel Partial2 [ get; set; }
        public Partial4ViewModel Partial4 { get; set; }
    
        public OtherMainViewModel() {}
    
        public OtherMainViewModel() {
            Partial2 = new Partial2ViewModel();
            Partial4 = new Partial4ViewModel();
        }
    }
