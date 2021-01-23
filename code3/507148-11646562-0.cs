    public IList<Item> FetchData()
    {
      using (ItemDataContext context = new ItemDataContext(_connectionString))
      {
        //....
        var results = new List<Item>();
        foreach (Item it in contextItems)
        {
          results.Add(it);
        }
        return results;
      }
    }
    public void LoadData()
    {
      Observable.Start(()=>FetchData())
                .ObserveOnDispatcher()
                .Subscribe(list=>
                  {
                    foreach (Item it in contextItems)
                    {
                      this.Checklist.Add(it);
                    }
                  });
    }
