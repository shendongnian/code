    public class MyViewModel
    {
        public MyViewModel(ICollection<MyEntity> entities)
        {
            this.Entities = new ObservableCollection<MyEntityViewModel>(entities.Select(e => new MyEntityViewModel(e)));
            // this will keep two collections synchronized:
            this.Entities.CollectionChanged += (sender, args) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        entities.Add((MyEntity)e.NewItems[0]);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        entities.Remove((MyEntity)e.OldItems[0]);
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        entities.Remove((MyEntity)e.OldItems[0]);
                        entities.Add((MyEntity)e.NewItems[0]);
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        entities.Clear();
                        break;
                }
            }
        }            
        public ObservableCollection<MyEntityViewModel> Entities { get; private set; }
    }
