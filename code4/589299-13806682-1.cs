    protected void Page_Load(object sender, EventArgs e)
    {
          Blist = (List<string>)Session["items"];
          if (!Page.IsPostBack)
          {
             
             if (Blist != null)
             {
                 ListBox1.Items.Clear();
                 for (int i = 0; i < Blist.Count; i++)
                     ListBox1.Items.Add(Blist[i]);
             }
         }
     }
