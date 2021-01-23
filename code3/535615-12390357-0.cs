    public abstract class BaseDetailsViewModel
    {
        public BaseDetailsViewModel() {
            Timer = new List<long>();
        }
        public List<long> Timer { get; set; }
    }
