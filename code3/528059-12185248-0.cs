    protected void Page_Load()
    {
     if(!IsPostBack) 
     { 
        List<string> gvValues = new List<string>(); 
        GridView1.DataSource = gvValues;
        GridView1.DataBind();
        Session["Data"] = gvValues;    
     }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {       
       List<string> lt = new list<string>();
       lt = (List<String>) Session["Data"]; 
       lt.Add(TextBox1.Text);  
       GridView1.DataSource = lt;
       GridView1.DataBind();
       Session["Data"] = lt;  // Save it in Session, so it available next time
    }
