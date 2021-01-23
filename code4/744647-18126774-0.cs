     `List<Class1> data = new List<Class1>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            
            }
            if (Session["test"] != null)
            {
                data = Session["test"] as List<Class1>;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Class1 cl = new Class1 { ID = Convert.ToInt16(TextBox1.Text), Name = TextBox2.Text, LastName = TextBox3.Text };
            data.Add(cl);            
            Session["test"] = data;
            dataBind();
        }
        
        protected void dataBind()
        {
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
    }
}`   
