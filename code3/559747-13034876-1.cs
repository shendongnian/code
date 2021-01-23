    public static Uri MergerUri(Uri uri1, Uri uri2)
    {
        if(!string.IsNullOrWhiteSpace(uri1.Query))
          {
            return new Uri(uri1, uri2.GetLeftPart(UriPartial.Path) + uri1.Query + "&" + uri2.Query);
          }
        else return new Uri(uri1, uri2.ToString());
    }
