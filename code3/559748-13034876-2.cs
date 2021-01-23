    public static Uri MergerUri(Uri uri1, Uri uri2)
        {
            if (!string.IsNullOrWhiteSpace(uri1.Query))
            {
                string[] split = uri2.ToString().Split('?');
                
                return new Uri(uri1, split[0] + uri1.Query + "&" + split[1]);
            }
            else return new Uri(uri1, uri2.ToString());
        }
