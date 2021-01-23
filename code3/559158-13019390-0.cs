        public void Distribute<TEntity>(ComboBox cb, BooksDBDataContext db, string valueField, string displayField)
                        where TEntity : class
        {
           
         
            var data = db.GetTable<TEntity>();
          
            cb.ValueMember = valueField;
            cb.DisplayMember = displayField;
            cb.DataSource = data;
        }
