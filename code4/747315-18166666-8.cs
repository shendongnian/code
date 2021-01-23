    private async void button1_Click(object sender, EventArgs e)
    {
        txtLog.AppendText("Before Await");
        
        //Note I changed from "Task<bool>" to "bool", await is like calling ".Result" 
        //  on a task but not blocking the UI, so you store the type you are waiting for.
        bool result = await login("",""); 
        
        txtLog.AppendText("After Await");
        txtLog.AppendText("Result: " + result.ToString());
    }
    private Task<bool> login(String username, String password)
    {
        var tcs = new TaskCompletionSource<bool>();
        // Make the login request
        var request = new RestSharp.RestRequest("/accounts/login/", RestSharp.Method.POST);
        request.AddParameter("username", username);
        request.AddParameter("password", password);
        client.ExecuteAsync(request, (response, handle) =>
            {
                try
                {
                    // Return loggin status
                    var dom = response.Content;
                
                    //dom["html"] did not have a .HasClass in my tests, so this code may need work.
                    tcs.TrySetResult(dom["html"].HasClass("logged-in")); 
                }
                catch(Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            });
        return tcs.Task;
    }
