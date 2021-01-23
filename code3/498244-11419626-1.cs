    string responseString = "TOKEN=EC......";
    var dict = HttpUtility.ParseQueryString(responseString);
    GetExpressCheckoutDetailsResponse respObj = new GetExpressCheckoutDetailsResponse();
    foreach (var p in respObj.GetType().GetProperties())
    {
        p.SetValue(respObj, dict[p.Name]);
    }
    //respObj is ready to use
