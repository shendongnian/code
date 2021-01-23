    string[] segments = Request.Url.Segments;
    string result = string.Empty;
    segments.ToList().ForEach(s =>{
                                      if(s!= segments[segments.Length-1])
                                          result += s;
                              });
