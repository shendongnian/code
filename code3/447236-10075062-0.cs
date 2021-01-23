    const string CUSTOMERITEM = "customeritem";
    public Customer Current
    {
        get
        {
            if ( HttpContext.Current.Items[CUSTOMERITEM] == null )
            {
               int id = retrieve_the_id;
               using ( DbContext ctx = GetCurrentDbContext() ) 
               {
                   HttpContext.Current.Items.Add( CUSTOMERITEM, ctx.Customers.FirstOrDefault( c => c.ID == id );
               }
            }
            return (Customer)HttpContext.Current.Items[CUSTOMERITEM];
        }
    }
