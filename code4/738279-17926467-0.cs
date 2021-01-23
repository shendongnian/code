    public class VehicleState
    {
        public float _passengers;
        public float _CommitedPassengers;
        public float passengers
        {
            set { _passengers = value; }
            get { return _passengers; }
        }
        public float CommitedPassengers
        {
            get { return _CommitedPassengers; }
        }
        public void CommitState()
        {
            _CommitedPassengers = _passengers;
    
        }
    } 
