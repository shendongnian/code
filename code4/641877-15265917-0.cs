    void entityInstantFeedbackSource_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e) {
        //... connection initialization ...
        var context = new ObjectContext(ecsb.ConnectionString);
        ObjectSet<Person> personSet = context.CreateObjectSet<Person>();
        e.QueryableSource = personSet;
        e.Tag = context;
    }
    void entityInstantFeedbackSource_DismissQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e) {
        ((ObjectContext)e.Tag).Dispose();
    }
