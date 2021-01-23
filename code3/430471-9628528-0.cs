    XElement root = new XElement("Orders");
    using (SqlConnection con = new SqlConnection(ConnectionString))
    {
        con.Open();
        using(SqlCommand command = new SqlCommand("select orderID,qty,orderDate,deliveryDate from Orders", con))
        {
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                root.AddFirst(
                    new XElement("Order", 
                    from i in Enumerable.Range(0, reader.FieldCount)
                        select 
                            new XElement(reader.GetName(i), reader.GetValue(i))
                    )
                );
            }
            root.Save(Console.Out);
        }
    }
