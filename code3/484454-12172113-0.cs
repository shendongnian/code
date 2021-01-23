    class YourModel
    {
        public class DataChangedEventArgs : EventArgs
        {
            ...
        }
        public delegate void DataChangedDelegate(object oSender, DataChangedEventArgs args);
        //---- public event that clients subscribe to
        public event DataChangedDelegate evtDataChanged;
        //---- any changes in YourModel invoke this method to notify clients
        protected void OnChanged(DataChangedEventArgs args)
        {
            if (evtDataChanged != null)
                evtDataChanged(this, args);
        }
        public void ImaDataChanger(...) 
        {
            //---- stuff that changes the data
            OnChanged(args);    //-- notify clients
        }
    }
    class UserSelectionView
    {
        public void DataChangedHandler(object oSender, YourModel.DataChangedEventArgs args)
        {
            //---- process update or refresh data
            //---- UI updates will have to be marshalled to the UI thread
        }
        public void Subscribe(YourModel model)
        {
            model.evtDataChanged += new YourModel.DataChangedDelegate(DataChangedHandler);
        }
    }
