    public void TestMethod1()
    {
        System.Net.WebClient client = new System.Net.WebClient();
        client.BaseAddress = "http://www.teejoo.com";            
        
        //Invoke your function here
        client.OpenReadAsync(new Uri("http://www.teejoo.com/YourLogicalPage.aspx"));
        //Pur your logical in your page, so you can use httpContext 
        client.OpenReadCompleted += new System.Net.OpenReadCompletedEventHandler(client_OpenReadCompleted);
    }
    
    void client_OpenReadCompleted(object sender, System.Net.OpenReadCompletedEventArgs e)
    {            
        //to Check the response HERE
    }
