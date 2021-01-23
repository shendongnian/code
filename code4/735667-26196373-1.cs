    public class VM
    {
      readonly SerialDisposable subscription;
    
      public VM()
      {
        subscription = new SerialDisposable();
        Things = new ObservableCollection<Thing>();
        Things.CollectionChanged += ThingsCollectionChanged;
      }
      void ThingsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
      {
        subscription.Disposable = 
          Things.Select(t => t.WhenPropertyChanged())
                .Merge()
                .Subscribe(OnThingPropertyChanged);
      }
      void OnThingPropertyChanged(PropertyChangedEventArgs obj)
      {
        //ToDo!
      }
    
      public ObservableCollection<Thing> Things { get; private set; }
    }
