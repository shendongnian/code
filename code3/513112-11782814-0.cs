    public class SeeSharp
    {
        public string Number
        {
            get
            {
                return _number.ToString();
            }
            set
            {
                if (!int.TryParse(value, out _number))
                    _number = default(int);
            }
        }
        public int _Number { get; set; }
    }
