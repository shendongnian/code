    public void Distribute<TEntity>(ComboBox cb, 
                                    DbContext db, 
                                    string valueField, 
                                    string displayField) 
                            where TEntity : class
    {
        //Publishers table
        var data = db.Set<TEntity>() as IEnumerable;
        cb.ValueMember = valueField;
        cb.DisplayMember = displayField;
        cb.DataSource = data;
    }
