    public void ProcdureMultiTableQuery()
    {
        var session = Session;
        var procSQLQuery = session.CreateSQLQuery("exec [proc_Name] ?,?");// prcodure returns two table
        procSQLQuery.SetParameter(0, userId);
        procSQLQuery.SetParameter(1, page);
        procSQLQuery.AddEntity(typeof(Question));
    
        var multiResults = session.CreateMultiQuery()
            .Add(procSQLQuery)
            // More table your procedure returns,more empty SQL query you should add
            .Add(session.CreateSQLQuery(" ").AddEntity(typeof(Question))) // the second table returns Question Model
            .List();
        if (multiResults == null || multiResults.Count == 0)
        {
            return;
        }
        if (multiResults.Count != 2)
        {
            return;
        }
        var questions1 = ConvertObjectsToArray<Question>((System.Collections.IList)multiResults[0]);
        var questions2 = ConvertObjectsToArray<Question>((System.Collections.IList)multiResults[1]);
    }
    static T[] ConvertObjectsToArray<T>(System.Collections.IList objects)
    {
        if (objects == null || objects.Count == 0)
        {
            return null;
        }
        var array = new T[objects.Count];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = (T)objects[i];
        }
        return array;
    }
