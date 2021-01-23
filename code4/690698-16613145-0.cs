         PagedDataSource pg = null;
            protected void Page_Init(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    pg = new PagedDataSource();
                    
                }
            }
        
          protected void Page_Load(object sender, EventArgs e)
                {
           if (!IsPostBack)
                    {
                      
                        
                        pg.DataSource = dt.DefaultView;
                        pg.AllowPaging = true;
                        pg.PageSize = 2;
        
                        
        
                        dlPagedControl.DataSource = pg;
                          
                        Session["DataTable"] = dt;  //dt is just a  datatable replace it with whatever you need
                        Session["CurrentPage"] = pg.CurrentPageIndex;
                        
                        dlPagedControl.DataBind();
                    
                    }
        }
        
        
           protected void cmdPrev_Click(object sender, EventArgs e)
                {
        
                    if(int.Parse(Session["CurrentPage"].ToString())!=0)
                    {
                    if (pg == null)
                    {
                        pg = new PagedDataSource();
                        pg.PageSize = 2;
                        pg.AllowPaging = true;
                    }
                    pg.DataSource = (Session["DataTable"] as DataTable).DefaultView;
                   
                    
                    pg.CurrentPageIndex = (int.Parse(Session["CurrentPage"].ToString())) - 1;
        
                    dlPagedControl.DataSource = pg;
                    dlPagedControl.DataBind();
                    Session["CurrentPage"] = pg.CurrentPageIndex;
    
                      lable1.Text=pg.CurrentPageIndex;
                    }
        
        
        
        
        
                }
         protected void cmdNext_Click_Click(object sender, EventArgs e)
                {
                  
        
                    if (pg == null)
                    {
                        pg = new PagedDataSource();
                        pg.PageSize = 2;
                        pg.AllowPaging = true;
                    }
                    pg.DataSource = (Session["DataTable"] as DataTable).DefaultView;
                   pg.CurrentPageIndex = (int.Parse(Session["CurrentPage"].ToString())) + 1;
                    
                    dlPagedControl.DataSource = pg;
                    dlPagedControl.DataBind();
                    Session["CurrentPage"] = pg.CurrentPageIndex;
    //show Current Page in Label
    lable1.Text=pg.CurrentPageIndex;
                } 
