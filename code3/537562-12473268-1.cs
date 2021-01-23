    if (NavigationContext.QueryString.TryGetValue("selectedItemSearch", out selectedIndexSearch))
            {
                //int indexSearch = int.Parse(selectedIndexSearch);
                //DataContext = App.ViewModel.AllToDoItems[indexSearch];
                
                int id = int.Parse(selectedIndexSearch);
                DataContext = GetById(id);
            }
    public object GetById(int id)
    {
 	    for(int i = 0; i < App.ViewModel.AllToDoItems.Count; i++)
        {
            if (App.ViewModel.AllToDoItems[i].ToDoItemId == id) 
            return App.ViewModel.AllToDoItems[i];
        }
        return null;
    }
