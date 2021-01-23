    static bool HasData<T>(int id, Expression<Func<AgeLength, T>> predicate)
    {
        using (MyDataContext dc = new MyDataContext())
        {
            return (from s in dc.Str_table
                    where s.sId == id
                    select s.AgeLengths
                    .Any(predicate)
                   ).FirstOrDefault();
        }
    }
