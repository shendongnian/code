    public class StatefulObject
    {
        private string _propertyOne;
        public StatefulObject()
        {
            this.Modified = false;
        }
    
        public string PropertyOne
        {
            get { return this._propertyOne; }
            set
            {
                if (this._propertyOne != value)
                {
                    this._propertyOne = value;
                    this.Modified = true;
                }
            }
        }
        public bool Modified { get; private set; }
    }
