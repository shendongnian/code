        public class ObservableCollectionEx<T> : ObservableCollection<T>
        {
            public event EventHandler CollectionEmpty;
            protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                if (this.Count == 0)
                {
                    var eventCopy = this.CollectionEmpty;
                    if (eventCopy  != null)
                    {
                        eventCopy(this, EventArgs.Empty);
                    }
                }
                base.OnCollectionChanged(e);
            }
        }
