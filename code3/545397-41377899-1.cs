    var helper = new GoogleAnalyticsHelper("UA-XXXXXXXXX-XX", "555");
    var result = helper.TrackEvent("Orders", "Order Checkout", "OrderId #31337").Result;
    if (!result.IsSuccessStatusCode)
    {
        new Exception("something went wrong");
    }
