    public interface IId
    {
      string Id {get;}
    }
    private static IEnumerable<ddlOptions> GetDDLOptionsViewModel<T>
        (IEnumerable<T> list, Func<T,string> propAccess)
       where T:IId
    {
       return list.Select(l => new DdlOption
        {
            Id = l.Id,
            DisplayName = propAccess(l)
        });
    }
