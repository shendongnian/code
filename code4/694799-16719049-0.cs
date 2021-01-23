    public interface IInstances
    {
        DbSet<Instance> Instances { get; }
    }
    
    public FirstDBDataContext :DbContext, IInstances
    {
        //Normal implementation
    }
    
    public SecondDBDataContext :DbContext, IInstances
    {
        //Normal implementation
    }
---
    bool _usefirstdb; 
    IInstances _db;
    if (_usefirstdb) 
    {
        _db =  new FirstDBDataContext (string.Format(SqlScripts.SqlServerConnectionString, args[1], args[2]));
    }
    else
    {
        _db =  new SecondDBDataContext(string.Format(SqlScripts.SqlServerConnectionString,args[1], args[2]));
    }
    var query = from inst in _db.Instances
        where inst.Name.Equals(args[3])
        select inst.Id;
