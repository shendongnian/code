    string nameval = string.empty;
    string name = "Select Name from login";
    string connection= "connection string path";
    SqlConnection connect = new SqlConnection(connection);
    SqlCommand command = new sqlCommand(name,connect);
    using(connect)
    {
       var data = command.ExecuteScalar();
       if(data!=null) {nameval = data.ToString();}
    }
