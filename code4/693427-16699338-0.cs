    public class DataStruct {
        public int Id { get; private set; }
        public event EventHandler Event1; // Can't be called by other classes
        
        // you need to pass those parameters to the event when called.
        public void fireEvent1{Event1(this, new EventArgs());} 
        // Delegates *can* be called by other classes, but only with all parameters passed.
        public delegate void DelegateHandler(DataStruct sender);
        public DelegateHandler NewEvent;
        // To avoid passing parameters, you need to do exactly what you did with the event
        public void RaiseDelegate() { NewEvent(this); }
        public void DelegateHandler(DataStruct sender) {
            MessageBox.Show(string.Format(
                "{0} raises event", sender.Id));
        }
    }
