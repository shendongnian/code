    protected void Page_Load(object sender, EventArgs e)
     {
         if (this.IsPostBack)
         {
            string command = SqlDataSource1.SelectCommand; // added just for debug purpose
            SqlDataSource1.SelectCommand = "SELECT  * from tblCourse where 
                                            name='"+textbox1.text+"'";
            SqlDataSource1.DataBind();
            gridview1.DataBind();
          }
           
      }
