    public static IEnumerable<Foo> GetAllFoos(String columnFilter = null)
    {
        const string sql = @"SELECT 
                        Columns ...
                     FROM 
                        dbo.TableFoo
                     WHERE
                        @SomeColumn IS NULL OR SomeColumn = @SomeColumn
                     ORDER BY
                         OrderColumn1 ASC, OrderColumn2 DESC";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                if (columnFilter == null)
                    cmd.Parameters.AddWithValue("@SomeColumn", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@SomeColumn", columnFilter);
                connection.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    var list = new List<Foo>();
                    while (rdr.Read())
                    {
                        var foo = new Foo();
                        foo.Prop1 = rdr.GetInt32(0);
                        foo.Prop2 = rdr.GetString(0);
                        list.Add(foo);
                    }
                    return list;
                }
            }
        }
    }
