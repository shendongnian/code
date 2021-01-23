    string SentValue;
    //
    protected void Page_Load(object sender, System.EventArgs e)
    {
      if (Request.QueryString.Count > 0) {
        SentValue = Request.QueryString.Item(0);
      } else {
        SentValue = "Nothing Doing!";
      }
    }
