    using(var scope = new TransactionScope(TransactionScopeOption.Required,
                          new TransactionOptions{IsolationLevel = IsolationLevel.Serializable}))
    {
        using(var dataContext = new DataContext())
        {
            var version = dataContext.Table.Where(item => item.Text == textBox1.Text)
                                           .Max(item => item.Version);
            var t = new Table
            {
                Text = textBox1.Text,
                Version = version + 1
            };
            dataContext.Table.InsertOnSubmit(t);
            dataContext.SaveChanges();
            scope.Complete();
        }
    }
