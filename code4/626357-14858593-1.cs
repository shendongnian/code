    using(Db db = new Db())
    {
    //changes
    if(db.SaveChanges)
    {
       //some message using db.DbChanges 
    }
    else
    {
        //handle errors in db.vErrors
    }
