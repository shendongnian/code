    string connString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;DataSource={0};Extended Properties=\"text;HDR=Yes;Format=Delimited(|)\";", dir);
    
    try
    {
    	dAdapter.Fill(dt);
    }
    catch (Exception exc)
    {
    	string myErrorMsg = exc.Message;
    }
