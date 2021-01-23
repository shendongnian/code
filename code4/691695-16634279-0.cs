    SqlCommand command = new SqlCommand();
    if (TId != null)
    {
        command.CommandText = "Select Article_Name, Id, Privacy_Term from Articles where Id=@id and T_Id = @tid";
        command.Parameters.Add("@tid", SqlDbType.BigInt).Value = TId;
    }
    else
    {
        command.CommandText = "Select Article_Name, Id, Privacy_Term from Articles where Id=@id and T_Id is null";
    }
    command.Parameters.Add("@id", SqlDbType.BigInt).Value = Id;
    command.Connection = connection;
    SqlDataAdapter Adapter = new SqlDataAdapter();
    Adapter.SelectCommand = command;
    Adapter.Fill(TableArticles);
