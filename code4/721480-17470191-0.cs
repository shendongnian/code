    protected void Page_Load(object sender, EventArgs e)
    {
       if (!isPostBack){
          ViewState["FLAG"] = false;
       }
       else{
          if ((bool)ViewState["FLAG"]) BindData();
       }
    }
    
    protected void btnload_Click(object sender, EventArgs e)
    {        
       ViewState["FLAG"] = true;
    }
