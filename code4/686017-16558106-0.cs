        string url = "~/LB/lct.aspx?pid=177&cat=Happily In Love"; //your input
        string[] arr = url.Split('?');
        var nameValues = HttpUtility.ParseQueryString(arr[1]);
        foreach (var n in nameValues.AllKeys)
        {
            nameValues.Set(n, HttpUtility.UrlEncode(nameValues[n]));
        }
        url = arr[0] + "?" + nameValues.ToString(); //your output
