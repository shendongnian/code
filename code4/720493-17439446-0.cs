    class StateMonitor
    {
        public enum States { initial, on, off, maintaining };
        public delegate void Mydelegate(States stFrom, States stTo);
        public event Mydelegate SomethingHappened;
        public States _state;
        public StateMonitor()
        {
            SomethingHappened += new Mydelegate(monitor);
            _state = States.initial;
        }
        public States state
        {
            get
            {
                return this._state;
            }
            set
            {
                if (SomethingHappened != null)
                {
                    SomethingHappened(this._state, value);
                }
                _state = value;
            }
        }
        public void monitor(States stateFrom, States stateTo)
        {
            if (stateFrom == States.initial && stateTo == States.on)
            {
                // Do something for from Intitial state to On State
            }
            else if (stateFrom == States.on && stateTo == States.off)
            {
                // Do something for from On state to Off State
            }
            //... the rest of the code here
        }
    }
