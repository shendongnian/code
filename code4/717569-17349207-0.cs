    using(var context = new LinqDbContext())
    {
        var results = context.Tablename;
        if(limitByConfEmail)
        {
            results = results.Where(data => data.ConfirmationEmail == true);
        }
        // do your elses here
    
        gridview.DataSource = results;
        gridview.DataBind();
    }
