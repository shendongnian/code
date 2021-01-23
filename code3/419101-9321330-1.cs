    public List<Guid?> InsertUpdate(News entity)
    {
        return UsingSqlTransaction(sqlTrans =>
        {
            var result = new List<Guid?>();
            result.Add(data.InsertUpdate(sqlTrans, entity));
            result.Add(data.DoSomethingElse(sqlTrans, entity));
            return result;
        });
    }
