    public class SortableBindingList<T> : BindingList<T>, INotifyPropertyChanged
        where T : class
    {
        public void Add(INotifyPropertyChanged item)
        {
            item.PropertyChanged += item_PropertyChanged;
            base.Add((T)item);
        }
        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChanged(sender, new PropertyChangedEventArgs(String.Format("{0}:{1}", sender, e)));
        }
        // other content in the method body
    }
