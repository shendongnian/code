            string url = "http://www.xxx.com/aaa/bbb.jpg";
            Uri uri = new Uri(url);
            string path_Query = uri.PathAndQuery;
            string extension =  Path.GetExtension(path_Query);
            path_Query = path_Query.Replace(extension, string.Empty);// This will remove extension
    ...................
