    using(DataContext db = new DataContext())
    {
        var name = db.Employee.Where(n => n.F_name == YourNameFromTextBox).FistOrDefault();
        if(name == null)
        {
            // insert data
        }
        else
        {
            // record exist - throw error
        }
    }
