    public class Experiment<T> where T : Sample
    {
        private List<T> _Samples = new List<T>();
        public IReadOnlyCollection<T> Samples
        {
            get { return _Samples.AsReadOnly(); }
        }
    
        public Experiment()
        {
        }
    
        public Experiment(IEnumerable<T> samples)
        {
            _Samples = samples.ToList();
        }
    
        public void AddSample(T sample)
        {
            _Samples.Add(sample);
            sample.Experiments.Add(new Experiment<Sample>(_Samples)); // The problem lies here
        }
    }
    
    public abstract class Sample
    {
        private List<Experiment<Sample>> _Experiments = new List<Experiment<Sample>>();
        public ICollection<Experiment<Sample>> Experiments
        {
            get { return _Experiments ; }
        }
    }
