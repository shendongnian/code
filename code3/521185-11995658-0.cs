    public class Person
    {
        string _state = string.Empty;
        public string State
        {
            get { return _state; }
            set { _state = value ?? string.Empty; }
        }
    }
