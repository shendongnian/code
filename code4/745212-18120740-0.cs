    using (...)
    {
        Cause c = db.Causes.FirstOrDefault(ce => ce.IsCurrent == true);
        if (cause.Title != c.Title)
        {
            c.IsCurrent = false;
            cause.IsCurrent = true;        
        }
    
        //
        // other codes ...
        //
    }
