    [DataContract]
    public class DataTransferObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            dynamic app = Application.Current;
            if(app != null) //Prevents execution on server-side.  This code is meant to only execute at the client
            {
                PropertyChanged += (sender, args) =>
                                       {
                                           app.IsAnythingDirty = true;
                                       };
            }
        }
    }
