    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
       {
        // Validate initially to force asterisks
        // to appear before the first roundtrip.
        Dictionary<int, string> dict = new Dictionary<int, string>();
        dict.Add(1, "apple");
        dict.Add(2, "bat");
        dict.Add(3, "cat");
        ddl.DataSource = dict;
        ddl.DataValueField = "Key";
        ddl.DataTextField = "Value";  //will display in ddl
        ddl.DataBind();
       }
    }
