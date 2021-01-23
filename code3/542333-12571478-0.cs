        List<string> keys = new List<string>() { "name", "age", "param3" };
        string url = "http://www.test.com/test.aspx?testinfo=&|&;";
        Regex reg = new Regex("&");
        int count = url.Count(p => p == '&');
        for (int i = 0; i < count; i++)
        {
            if (i >= keys.Count)
                break;
            url = reg.Replace(url, keys[i], 1);
        }
