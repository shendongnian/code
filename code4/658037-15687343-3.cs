    public class FooViewModel : ViewModelBase
    {
        public int CurrentPareto { get; set; }
        public int NewPareto { get; set; }
        public bool pNew { get { return CurrentPareto < NewPareto; } }
    }
