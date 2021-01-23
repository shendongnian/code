    //Write SQLCommand to get the data in url variable, suppose you have GetDataFromDatabase method written in your helper static class or somewhere else in the page gives stored url from database
    string url = GetDataFromDatabase();
    if (Request.Url.ToString().ToLower().Equals(url.ToLower()))
    {
        Response.Status = "301 Moved Permanently";
        Response.AddHeader("Location", url);
    }
