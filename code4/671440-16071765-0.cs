    public class GenericViewModel<T>
    {
        public List<T> Results { get; set; }
        public GenericViewModel()
        {
            this.Results = new List<T>();
        }
    }
