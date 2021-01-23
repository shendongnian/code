    Uri uri = new Uri(Request.Url.ToString());
    string[] segments = uri.Segments;
    string result = string.Format("{0}://{1}",uri.Scheme, uri.Host);
    segments.ToList().ForEach(s =>
                                 {
                                    if(s!= segments[segments.Length-1])
                                         result += s;
                                 });
