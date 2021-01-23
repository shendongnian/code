    public Application(string Name, System.Nullable<DateTime> modifiedDate)
    {
       if(modifiedDate != null)
         //ModifiedDate = Convert.ToDateTime(01.01.2000);
         ModifiedDate = DateTime.Now;
       else
       Do stuff
    }
