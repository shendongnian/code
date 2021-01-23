    public IEnumerable<T> GetAll<T>()
    {
        if (typeof(T).Equals(typeof(Models.Customer))
        {
            DataView results;
            // some DAL retrieval code
            foreach (DataRowView row in results)
            {
                yield return (T) new Models.Customer(row["Label"].ToString());
            }
        }
    }
