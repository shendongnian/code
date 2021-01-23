    public void Format(Table table)
    {
        table.BorderWidth = 2;
        table.BorderColor = Color.GloriousPink;
    }
    
    foreach(Table table in tables) 
    {
       Format(table);
    }
