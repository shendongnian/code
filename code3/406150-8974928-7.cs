    public class Entity
        {
            private decimal _WifeCount;
            public EventHandler WifeCountChanged;
            public decimal WifeCount 
            {   
                get {return _WifeCount;}   
                set
                {
                    _WifeCount = value;
                    OnWifeCountChanged();
                }
            }
    
            protected void OnWifeCountChanged()
            {
                if (this.WifeCountChanged != null)
                    this.WifeCountChanged(this, EventArgs.Empty);
            }
        }
