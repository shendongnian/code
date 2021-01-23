    using(MyContext ctx = CreateMyContext())
    {
         ctx.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
         // Get the user session for the client session         
         ...
    }
