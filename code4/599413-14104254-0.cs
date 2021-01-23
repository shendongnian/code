    public List<T> GetList<T>(string sp_List_Rows)
        where T : IData, new()
    {
        List<T> myList = new List<T>();
        Connection cnx = new Connection;
        Command cmd = new Command(sp_List_Rows, cnx);
        cnx.Open;
        IDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            T item = new T();
            item.FillFromReader(dr);
            myList.Add(item);
        }
        dr.Close();
        cnx.Close();
        return myList();
    }
