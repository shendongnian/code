     public void ProcessRequest(HttpContext context)
    {   
        HttpResponse response = context.Response;
        
        // Get the URL requested by the client (take the entire querystring at once
        //  to handle the case of the URL itself containing querystring parameters)
        string uri = Uri.UnescapeDataString(context.Request.QueryString.ToString());
        // Get token, if applicable, and append to the request
        string token = getTokenFromConfigFile(uri);
       
        // Add the 'TIMESTAMP' Value  to the Valtus Service
        string styleparam = "&STYLES=";
        if (uri.Contains(styleparam))
        {
            int position = uri.IndexOf(styleparam) + styleparam.Length;
            uri = uri.Insert(position, "TIMESTAMP");
        }
        
        System.Net.WebRequest req = System.Net.WebRequest.Create(new Uri(uri));
}
