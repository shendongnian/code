    [DataContract]
    public class AssetHolder<T> : Dictionary<string, T>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged where T : Asset 
    {
        IEnumerator IEnumerable.GetEnumerator() // this one is called by WPF objects like DataGrids 
        {
            return base.Values.GetEnumerator();
        }
        new public IEnumerator<T> GetEnumerator() // this enumerator is called by the foreach command in c# code 
        {
            return base.Values.GetEnumerator();
        }
        event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }
    }
