    public class MyThingCollection : ObservableCollection<MyThing>
    {
        public void RaiseResetCollection()
        {
            OnCollectionChanged(new 
                NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
