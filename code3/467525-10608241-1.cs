    int id;
    if(int.TryParse(Request.QueryString["detailsID"],out id))
    {
      
    string sql= string.Format("select .. from .. where id={0}",id);// using SqlParameter is much better and secure
    // and execute your query and fetch the data reader
    while(reade.Read())
    {
     // bla bla bla
    }
    }
 
    
