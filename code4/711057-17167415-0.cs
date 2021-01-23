    List<Tuple<string, string>> sqlQueries = new List<Tuple<string, string>>();
    // The sql queries below shoudl match the same column names 
    // you want to pull back from the database for yoru report
    sqlQueries.Add(new Tuple<string, string>("Table1Name", "SELECT TOP 1 .... FROM ..."));
    sqlQueries.Add(new Tuple<string, string>("SubReportName", "SELECT TOP 1 .... FROM ..."));
    sqlQueries.Add(new Tuple<string, string>("SubReport2TableName", "SELECT TOP 1 .... FROM ..."));
    SqlConnection connection = new SqlConnection(ConnectionString);
    DataSet resultSet = new DataSet();
    foreach (var tuple in sqlQueries)
    {
        SqlDataAdapter adapter = new SqlDataAdapter(tuple.Item1, connection);
        DataTable schema = new DataTable();
        adapter.Fill(schema);
        schema.TableName = tuple.Item2;
        resultSet.Tables.Add(schema);
    }
    // write out the schema to a file
    string path = Path.Combine("PATH_TO_DATASET_XML.xml");
    using (var writer = File.CreateText(path))
    {
        writer.Write(resultSet.GetXmlSchema().Replace(" encoding=\"utf-16\"", ""));
    }
