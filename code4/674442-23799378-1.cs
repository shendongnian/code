    SqlConnection conn = new SqlConnection(@"server=server-pc; database=HMS; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                load_data();
            }
        }
    
       public void load_data()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from doc_master", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
       protected void Button1_Click1(object sender, EventArgs e)
       {
           CheckBox ch;
           for (int i = 0; i < GridView1.Rows.Count; i++)
           {
               ch = (CheckBox)GridView1.Rows[i].Cells[0].Controls[1];
               if (ch.Checked == true)
               {
          int id = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
          SqlCommand cmd = new SqlCommand("delete from doc_master where ID=" + id + " ", conn);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
               }
           }
    
           load_data();
       }
