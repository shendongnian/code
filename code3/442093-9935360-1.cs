    this.dbContext = new SmokeFireDBEntities(); 
    var members = from m in dbContext.Members
                 where new[] { "A", "P", "S", "J" }.Contains(m.Class.ShortName)
                 orderby m.Line
                 select m;
    this.dbContext.Dispose();//this will close the connection for you, and if you need it re-opened then either call new Entities() again or use the using statement
