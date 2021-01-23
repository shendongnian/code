    public class MyValue : IRecord<int>
    {
        private int _field1;
        public int Field1
        {
            get { return _field1; }
            set
            {
                if (value < 0 || value > 1000) {
                    throw new ArgumentException("Value of 'Field1' must be between 0 and 1000");
                }
                _field1 = value;
            }
        }
        public double Field2;
        #region IRecord<int> Members
        public int ID { get { return Field1; } }
        #endregion
    }
