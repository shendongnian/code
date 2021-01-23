    public static string GetRelativeUrl(url u) {
      switch (u) {
        case url.test1:
          return "/_layouts/Admin/test1.aspx";
        case url.test2:
          return "/_layouts/Admin/test2.aspx";
        case url.test3:
          return "/_layouts/Admin/test3.aspx";
        default: 
          // Handle bad URL, possibly throw
          throw new Exception();
      }
    }
