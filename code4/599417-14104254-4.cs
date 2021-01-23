    public List<T> GetList<T>(string sqlText)
        where T : IData, new()
    {
        List<T> myList = new List<T>();
        using (Connection cnx = new Connection(connString))
        using (Command cmd = new Command(sqlText, cnx)) {
            cnx.Open();
            using (IDataReader dr = cmd.ExecuteReader()) {
                while (dr.Read())
                {
                    T item = new T();
                    item.FillFromReader(dr);
                    myList.Add(item);
                }
            }
        }
        return myList();
    }
