    ...
        DataTableReader RS = dt.CreateDataReader();             
        byte[] byteArray = GetData(RS);             
    
        try   
        {
            context.Response.Clear();
            context.Response.ContentType = "application/ms-excel";   
            context.Response.OutputStream.Write(byteArray, 0, byteArray.Length);       
            context.Response.End();    
        }    
        catch (Exception ex)    
        {       
            SendMail(ex.Message.ToString());    
        }
    ...
