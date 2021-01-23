    foreach(var entry in harData.Log.Entries)
    {
        foreach (var cookie in entry.Request.Cookies)
        {
            string name = cookie.Name;
            string value = cookie.Value;
    
            // Do something exciting....or just write the values to Console :)
            Console.Write("Cookie name={0}, value={1}, name, value);
        }
    }
