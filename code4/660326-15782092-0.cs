    string FixQuery(string query){
      return String.Join("&",
        query.Split(new[] {'&'})
          .Select(
            p =>
              String.Join("=",
                p.Split(new[] {'='})
                  .Select(
                    q =>
                      HttpUtility.UrlEncode(
                        HttpUtility.UrlDecode(q),
                        Encoding.UTF8
                      )
                  )
              )
          )
      );
    }
    //example usage
    var url = "http://localhost:8080/search?"+FixQuery(query);
