    interface ISensor
    {
        int Id { get;  }    
        event Action<int> OnSignal;
    }
    
    class Sensor : ISensor
    {
        public int Id { get; private set; }    
        public event Action<int> OnSignal;
    
        public void Update(int signal)
        {
            if (OnSignal != null) OnSignal(signal);
        }
    }
    class SensorUser
    {
        public SensorUser(ISensor s)
        {
            s.OnSignal += SignalHandler;
        }    
    }
