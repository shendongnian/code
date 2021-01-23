    public static IEnumerable<address> GetByParams(Expression<Func<address, bool>> predicate, int? pageNumber, int? pageSize)
    {
        using (IDbConnection db = DbFactory.OpenDbConnection())
        {
            if ((pageNumber != null) && (pageSize != null))
            {
                var data = db.Select<address>(predicate).Skip((int) pageNumber).Take((int) pageSize).ToList();
                if (data.Any())
                {
                    data[0].TotalCount = data.Count();
                    data[0].TotalPages = (int) (data.Count()/pageSize);
                }
                return data;
            }
            //this is the code that creates the error
            return db.Select<address>(predicate);
        }
    }
