    // Steal concrete connection from Linq
    ModelDEmoWPFContainer l_ctx = new ModelDEmoWPFContainer();
    var l_connection = (System.Data.EntityClient.EntityConnection)l_ctx.Connection)
                                       .StoreConnection;
    
    System.Data.SqlClient.SqlCommand l_cmd = 
                      new System.Data.SqlClient.SqlCommand(query_arg);
    l_cmd.Connection = (System.Data.SqlClient.SqlConnection) l_connection;
    System.Data.SqlClient.SqlDataAdapter l_da = 
                     new    System.Data.SqlClient.SqlDataAdapter(l_cmd);
    System.Data.DataSet l_ds = new System.Data.DataSet();     
    l_da.Fill(l_ds);
