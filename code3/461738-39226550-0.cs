    using System.Data.Entity.Core.Objects;
    using System.Text.RegularExpressions;
    public void DeleteAll()
    {
        ObjectContext objectContext = ( (IObjectContextAdapter)context ).ObjectContext;
        string sql = objectContext.CreateObjectSet<T>().ToTraceString();
        Regex regex = new Regex( "FROM (?<table>.*) AS" );
        Match match = regex.Match( sql );
        string tableName = match.Groups[ "table" ].Value;
        context.Database.ExecuteSqlCommand( string.Format( "delete from {0}", tableName ) );
    }
