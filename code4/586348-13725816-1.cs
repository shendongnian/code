    public interface IPopulate {
       void Populate( DbDataReader dataReader );
    }
    ....
    private List<T> PopulateList<T>( GenericConnection gc )
        where T : IPopulate, new()
    {
        T v;
        var ret = new List<T>();
        var r = gc.ExecuteReader();
        while (r.Read())
        {
            v = new T();
            v.Populate(r);
            ret.Add(v);
        }
        r.Close();
        return ret;
    }
