    public AlphaProductesVM (){}
    public ObservableCollection<Alphabetical_list_of_product> NwCustomers
    {
        get { 
              if(_NwCustomers == null)
              {
                  _NwCustomers = new ObservableCollection<Alphabetical_list_of_product>();
                  var repository = new NorthwindRepository();
                      repository
                      .GetAllProducts()
                      .ObserveOn(SynchronizationContext.Current)
                      .Subscribe(AddElement);
              }
              return _NwCustomers; 
        }
    }
