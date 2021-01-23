    protected void Page_Load(object sender, EventArgs e){
     if (!IsPostBack)
        {
         ListBoxDelete.Items.Clear();
         List<string> itens = new List<string>();
          for(var item in itens){
           ListBoxDelete.Items.Add(item);
         }
      }
    }
