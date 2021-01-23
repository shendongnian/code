    public static List<T> GetList<T>(string userName) where T : class, IUserName
    {
        using (SqlUnitOfWork work = new SqlUnitOfWork())
        {
            return work.GetList<T>()
                .AsEnumerable()
                .Where(row => row.UserName == userName)
                .ToList();
        }
    }
