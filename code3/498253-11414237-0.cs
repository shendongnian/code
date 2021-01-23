    using (var myConnection = new SqlConnection("Server=xyz;Database=db;Uid=db;Pwd=12345"))
    {
        using (var myCommandddl = new SqlCommand("SELECT [username], [fullname] FROM [qa_users]", myConnection))
        {
            var table = new DataTable();
    
            using(var myAdapter = new SqlDataAdapter(myCommandddl))
                myAdapter.Fill(table);
    
            ddlrep.DataSource = table;
            ddlrep.DataValueField = "username";
            ddlrep.DataTextField = "fullname";
            ddlrep.DataBind();
        }
    }
