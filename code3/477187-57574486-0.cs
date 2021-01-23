csharp
var builder = new SQLiteConnectionStringBuilder("Data Source=./mydatabase.db") { BinaryGUID = true };
var connStr = builder.ToString();
return new SQLiteConnection(connStr);
Here's the official SQLite provider: https://www.nuget.org/packages/System.Data.SQLite.Core/
2. If using Dapper, you can have it automatically convert byte arrays to Guid using this class, which should be registered once as soon as your app starts:
csharp
public class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
{
    public override Guid Parse(object value)
    {
        var valueAsBytes = (byte[])value;
        return new Guid(valueAsBytes);
    }
    public override void SetValue(System.Data.IDbDataParameter parameter, Guid value)
    {
        var guidAsBytes = value.ToByteArray();
        parameter.Value = guidAsBytes;
    }
}
// And the registration in Startup.cs or equivalent:
SqlMapper.AddTypeHandler<Guid>(new GuidTypeHandler());
Source: [Dapper Issue #718 - GitHub](https://github.com/StackExchange/Dapper/issues/718)
