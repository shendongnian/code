    protected void button1_Click(object sender, EventArgs e)      
    {      
        string client = TextBox1.Text;      
        
        SourceDataContext db = new SourceDataContext();      
          
        GridView1.DataSource = from q in db.Cust      
                               where q.Client_Name == client      
                               orderby q.ID      
                               select q;      
        GridView1.DataBind();    
        
        GridView1.PageIndex = 0;
          
    }   
