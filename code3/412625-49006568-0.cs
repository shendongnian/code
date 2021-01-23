    HttpResponseMessage response = null;
    try
    {
    	using (var client = new HttpClient())
    	{
    	   response = client.PostAsync(
    		"http://localhost:8000/....",
             new StringContent(myJson,Encoding.UTF8,"application/json")).Result;
        if (response.IsSuccessStatusCode)
    		{
    			MessageBox.Show("OK");    			
    		}
    		else
    		{
                MessageBox.Show("NOK");
    		}
    	}
    }
    catch (Exception ex)
    {
    	MessageBox.Show("ERROR");
    }
