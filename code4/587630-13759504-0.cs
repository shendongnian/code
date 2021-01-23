    public class DataLayer
    {
        public string GetTitle(string myVar)
        {
            // Create the query we want
            string query = "SELECT title FROM MyTable " + 
                "WHERE var = @myVar";
            //ENTER PARAMETERS IN HERE
            // Now return the result to the view
            return this.dataProvider.ExecuteMySelectQuery(
                dr =>
                {
                   //DELEGATE DATA READER PASSED IN AND TITLE GETS RETURNED
                },
                query,
                parameters);
        }
    }
    public class DataProvider
    {
         public T ExecuteMySelectQuery<T>(Func<IDataReader, T> getMyResult, string selectQuery, Dictionary parameters)
        {
              //RUNS AND RETURNS THE QUERY
         }
    }
