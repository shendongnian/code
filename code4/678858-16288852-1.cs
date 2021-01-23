    private async void RefreshTodoItems()
    {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                var results = await todoTable
                    .Where(todoItem => todoItem.Complete == false)
                    .ToListAsync();
    
                items = new ObservableCollection<TodoItem>(results);
                ListItems.ItemsSource = items;
    }
