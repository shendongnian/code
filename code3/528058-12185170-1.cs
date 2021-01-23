    protected override void OnInit(EventArgs e)
    {
        GridView1.DataSource = GvValues;
        GridView1.DataBind();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
         GvValues.Add(TextBox1.Text);
         GridView1.DataSource = GvValues;
         GridView1.DataBind();
    }
    private List<string> GvValues
    {
      get
      {
        if(Session["list"] != null)
        {
          return (List<string>)Session["list"];
        }
         
         return new List<string>();
      }
    
      set
      {
        Session["list"] value;
      }
    }
