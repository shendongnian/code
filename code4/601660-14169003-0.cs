    try 
    {
        db.SaveChanges();
    }
    catch (DbUpdateException ex) 
    {
        UpdateException updateException = (UpdateException)ex.InnerException;
        SqlException sqlException = (SqlException)updateException.InnerException;
        foreach (SqlError error in sqlException.Errors)
        {
            // TODO: Do something with your errors
        }
    }
