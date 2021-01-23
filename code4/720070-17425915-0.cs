        public class ObservableCollectionEx<T> : ObservableCollection<T>
        {
            public event EventHandler CollectionEmpty;
            protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                if (this.Count == 0)
                {
                    if (this.CollectionEmpty != null)
                    {
                        this.CollectionEmpty(this, EventArgs.Empty);
                    }
                }
                base.OnCollectionChanged(e);
            }
        }
