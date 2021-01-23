    public class AddressList : IList<IPAdress>
    {
        public string Serialized { get; private set; }
    
        private List<IPAddress> _innerList = new List<IPAddress>();
        //To be informed when the list is modified.
        public event EventHandler OnModified;
    
        public AddressList(string serializedString)
        {
            //Init the collection from the serialized string
        }
    
        public void Add(IPAdress item)
        {
            _innerList.Add(item)
    
            //Update the serialized string
            UpdateString();
        }
    
        public void Remove(IPAdress item)
        {
            _innerList.Remove(item);
    
            //Update the serialized string
            UpdateString();
        }
        private void UpdateString()
        {
            //Do your update job.
            //Call the event.
            if (OnModified != null)
                OnModified(this, EventArgs.Empty);
        }
    
        //Rest of IList implementation....
    }
