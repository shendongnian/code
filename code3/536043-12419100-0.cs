    SqlCommand _nuecommand = new SqlCommand(); 
    SqlDataAdapter _nuweadapter = new SqlDataAdapter(); 
    SqlConnection conn = new SqlConnection(); 
     
    try   
     
    { 
        if (conn.State == System.Data.ConnectionState.Closed ||  
            conn.State == System.Data.ConnectionState.Broken) 
            { 
                conn.Open(); 
            } 
     
            string _sql = ""; 
            _nuecommand.Connection = conn; 
            _sql =  
                "SELECT [Field],[Field],Field,[Field],[VeField],FieldFROM [Table]" +  
                    " WHERE [Field] = 'value' AND [Field] = 'Value' AND" +  
                    " [Field] IS NULL "; 
            _nuecommand.CommandText = _sql; 
            _nuweadapter.SelectCommand = _nuecommand; 
            _nuecommand.CommandTimeout = 6000; 
            _nuweadapter.Fill(_dtnuwe); 
            dgnavrae.DataSource = _dtnuwe.DefaultView; 
            dgnavrae.databind(); 
     
    } 
    catch (Exception ex) 
    { 
        LogInInde.Pages.ErrorPage._error = ex.Message; 
        throw ex; 
    }
