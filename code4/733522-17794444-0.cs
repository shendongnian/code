    public abstract class Experiment<T> where T : Sample<T>
    {
        private List<T> _Samples;
        public IReadOnlyCollection<T> Samples {
            get { return _Samples.AsReadOnly(); }
        }
    
        public void AddSample(T sample)
        {
            _Samples.Add(sample); 
            sample.Experiments.Add(this); // The problem lies here
        }
    }
    
    public abstract class Sample<T> where T : Sample
    {
        private List<Experiment<T>> _Experiments;
        public ICollection<Experiment<T>> Experiments {
            get { return _Experiments; }
        }
    }
