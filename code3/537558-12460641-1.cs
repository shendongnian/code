    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.TryGetValue("selectedItemSearch", out selectedIndexSearch))
            {
                int id = int.Parse(selectedIndexSearch);
                DataContext = GetById(id)
            }
        }
    
      public ItemType GetByIf(id) 
      {
        for(int i = 0; i < App.ViewModel.AllToDoItems.Length; i++)
        {
            if(App.ViewModel.AllToDoItems[i].Id == id) return App.ViewModel.AllToDoItems[i];
        }
        return null;
      }
