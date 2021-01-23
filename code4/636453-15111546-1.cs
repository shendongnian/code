    public class BrowsedObject
    {
        public event EventHandler PropertyValueChanged;
    
        private void OnPropertyValueChanged(object sender, EventArgs e)
        {
            EventHandler eh = PropertyValueChanged;
            if (eh != null)
                eh(sender, e);
        }
    
        private string someProperty;
        public new string SomeProperty
        {
            get { return someProperty; }
            set
            {
                someProperty = value;
                OnPropertyValueChanged(this, EventArgs.Empty);
            }
        }
    }
