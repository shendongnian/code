    reviews = from item in xmlDoc.Descendants("node")
              select new 
              {
                  PubDate = (string)item.Element("created"),
                  Isbn = (string)item.Element("isbn"),
                  Summary = (string)item.Element("summary")
              };
    // Output:
    // {
    //      PubDate = 2012-01-23 12:40:57,
    //      Isbn = 123456789,
    //      Summary = Teh Kittehs like to play in teh mud
    // }
