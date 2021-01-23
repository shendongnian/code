    // Unrelated, but generally you want to use "async Task" 
    // in the method signature. "async void" should only be used by
    // event handlers, such as a click event.
    private async Task getBowlers()
    {
        SQLiteAsyncConnection conn = new SQLiteAsyncConnection(BOWLERS_DATABASE);
        var query = conn.Table<Bowler>();
        var result = await query.ToListAsync();
        // set page's data context to bowler collection
        this.DataContext = result;
    }
