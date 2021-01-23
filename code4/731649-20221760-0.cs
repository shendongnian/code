    Microsoft.SqlServer.Dts.Runtime.Package pkg = default(Microsoft.SqlServer.Dts.Runtime.Package);
    Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();
    
    pkg = app.LoadFromSqlServer("/Maintenance Plans/TestPackage", "DEEPTHOUGHT", null, null, null);
    pkg.Execute();
