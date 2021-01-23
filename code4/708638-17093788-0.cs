    public void getDocData()
    {
      String url = "https://spreadsheets.google.com/blah blah blah/basic?alt=json";
      using (var w = new WebClient())
      {
        //here's where the problem is
        String json_data = w.DownloadStringAsync(url);
        //blah blah parse json_data;
      }
    }
