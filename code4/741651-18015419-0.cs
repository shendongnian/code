    string authInfo = "AfKNLhCngYfGb-Eyv5gn0MnzCDBHD7T9OD7PATaJWQzP3I1xDRV1mMK1i3WO:ECSAgxAiBE00pq-SY9YB5tHw0fd2UlayHGfMr5fjAaULMD2NFP1syLY7GCzt";
    WebClient client = new WebClient();
    NameValueCollection values;
    
    values = new NameValueCollection();
    values.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(authInfo)));
    values.Add("Accept", "application/json");
    values.Add("Accept-Language", "en_US");
    
    client.UploadValues("https://api.sandbox.paypal.com/v1/oauth2/token", values);
