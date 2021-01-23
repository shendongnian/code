    using System.Data;
    ...
    var assembly = Assembly.LoadFile(@"path\to\System.Data.SQLite.dll");
    var type = assembly.GetType("System.Data.SQLite.SQLiteConnection");
    IDbConnection connection = (IDbConnection)Activator.CreateInstance(type);
