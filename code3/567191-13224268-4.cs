    public void LoadMoreItems()
    {
      if(Items.Last() is LoadMoreViewModel)
      {
        Items.Remove(Items.Last());
      }
      //Insert here add new items logic.
      Items.Add(new LoadMoreViewModel(_=>LoadMoreItems());
    }
