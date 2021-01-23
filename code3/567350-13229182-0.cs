    if(imageid != null)
    {
        SqlCommand command = new SqlCommand("
              select Image from ImageStore where ImageID=" + imageid, connection); 
        SqlDataReader dr = command.ExecuteReader();
        dr.Read();
        context.Response.BinaryWrite((Byte[])dr[0]);
    }
    else
    {
        SqlCommand command = new SqlCommand("
              select Image from ImageStore where ImageID=0", connection); 
        SqlDataReader dr = command.ExecuteReader();
        dr.Read();
        context.Response.BinaryWrite((Byte[])dr[0]);
    }
