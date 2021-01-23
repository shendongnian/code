     protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
        session["counter"]=0;
     }
     protected void Button1_Click(object sender, EventArgs e)
    {
        int count=(int)session["counter"];
        count++;
        session["counter"]=count;
        //remove response.redirect("same page");
     }
