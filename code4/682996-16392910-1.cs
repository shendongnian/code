    using (var client = new HttpClient())
    {
        // rest of your code goes here
        try
        {
            var repsonse = client.PostAsJsonAsync(fooURL, leaveRequest).Result;
        }
        catch(HttpRequestException httpEx)
        {
             // determine error here by inspecting httpEx.Message         
        }
    }
