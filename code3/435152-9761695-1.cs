    public List<T> LoadAll<T>(Func<T> create)
    {
        var list = new List<T>();
        if (T is ICustomer) {
            string sql = "SELECT * FROM tblCustomer";
            ...
            while (reader.NextResult()) {
                ICustomer cust = (ICustomer)create();
                cust.FirstName = reader.GetString("FirstName");
                ...
                list.Add((T)cust);
            }
        } else if (T is IOrder) {
            ...
        }
        return list;
    }
