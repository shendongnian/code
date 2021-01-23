    protected void Page_Load(object sender, EventArgs e)
    {
         if (ViewState["Collection"] == null)
         {
                ViewState["Collection"] = new List<int>();
         }//if
    }
    protected void button_clickSell(object sender, EventArgs e)
    {
         List<int> collection = (List<int>)ViewState["Collection"];
         collection.Add(7);
         collection.Add(9);
    }
    protected void button_clickView(object sender, EventArgs e)
    {
         List<int> collection = (List<int>)ViewState["Collection"];
         collection.Add(10);
    }
