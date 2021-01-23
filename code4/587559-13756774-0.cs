    using(var dbConn = new SqlConnection(Settings.Instance.DbConnectionString))
    {
        const String query = "SELECT TOP 10 Title, Content FROM Article";
        Func<SqlDataReader, Article> operation = reader => reader.ToArticle();
        foreach (var e in dbConn.SqlRetrieveMultiple(query, operation))
            yield return e;
    }
