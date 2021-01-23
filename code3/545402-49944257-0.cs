     string clientId = Guid.NewGuid().ToString();
     if (Request != null && Request.Cookies != null && Request.Cookies.Get("_ga") != null && Request.Cookies.Get("_ga").Value != null)
     {
        clientId = Request.Cookies.Get("_ga").Value;
        clientId = clientId.Replace("GA1.2.", "");
        clientId = clientId.Replace("GA1.1.", "");
     }
