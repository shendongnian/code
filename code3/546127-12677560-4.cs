    using (MyDataContext db = new MyDataContext()) {
    
        // Build out your base query, which would return everything from MyTable
        var results = (from m in db.MyTable
                       select m);
    
        // Check each textbox for a value to filter by.  Add the filter to the base
        // query where necessary.    
    
        if(!string.IsNullOrEmpty(txtUserId.Text)) {
            results = results.Where(x => x.UserId == (int) txtUserId.Text);
        }
    
        if(!string.IsNullOrEmpty(txtFirstName.Text)) {
            results = results.Where(x => x.FirstName == txtFirstName.Text);
        }
    
        if(!string.IsNullOrEmpty(txtLastName.Text)) {
            results = results.Where(x => x.LastName == txtLastName.Text);
        }
    
        // Loop over all of the rows returned by the previous query and do something with it.  
        // THIS is the actual point that the SQL would be generated from the query you've 
        // built and executed against the DB.  The elements returned by `results` 
        // should only meet all of the filters that you the user entered for one or
        // more of the fields.  Not entering any data would have resulted in all rows being
        // returned
        foreach (var m in results) {
            // m represents a single row in the results, do something with it.
            Console.WriteLine(m.UserId);
        }
    
    }
