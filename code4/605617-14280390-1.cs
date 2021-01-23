    private void SaveAll()
    {
        Repository repository = Repository.Instance;
        List<Product> products = (List<Product>)Source.DataSource;
        IEnumerable<object> objects = products.Cast<object>();
        repository.SaveAll<Product>(objects.ToList<object>());
        notificacionLbl.Visible = false;
    }
