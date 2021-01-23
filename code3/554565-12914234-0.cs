    public IEnumerable<IList<EdiEventLog>> GetAllLogs(List<String> eventTtypes)
    {
        _session = GetSession();
        const int pagesize = 1000;
        int page = 0;
        var query = from q in _session.Query<EdiEventLog>()
                    where eventTtypes.Contains(q.EventType)
                    orderby q.Id   // to make sure repeated queries return consistent results
                    select q;
        IList<EdiEventLog> results;
        do
        {
            results = query.Skip(page * pagesize).Take(pagesize).ToList();
            page++;
        } while(results.Count > 0);
    }
