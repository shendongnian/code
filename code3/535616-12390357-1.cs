    public abstract class BaseDetailsViewModel
    {
        protected BaseDetailsViewModel() {
            Timer = new List<long>();
        }
        public List<long> Timer { get; set; }
    }
