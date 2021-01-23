    public class Foo
    {
        // implement the abstract property
        public string PKField { get { return "ID"; } }
        public int ID { get; set; }
        private float _field1;
        public float Field1
        {
            get { return _field1; }
            set
            {
                _field1 = value;
                OnPropertyValueChanged("Field1", value);
            }
        }
        private string _field2;
        public string Field2
        {
            get { return _field2; }
            set
            {
                _field2 = value;
                OnPropertyValueChanged("Field2", value);
            }
        }
    }
