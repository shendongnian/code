    public void Distribute<TEntity>(ComboBox cb, 
                                    DataContext db, 
                                    string valueField, 
                                    string displayField) 
                            where TEntity : class
    {
        //Publishers table
        var data = db.Table<TEntity>() as IEnumerable;
        cb.ValueMember = valueField;
        cb.DisplayMember = displayField;
        cb.DataSource = data;
    }
