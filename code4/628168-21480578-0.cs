        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Session["Data"] == null) //Checking if the session contain any value.
            {
                DataTable dt = new DataTable(); //creating the columns.
                dt.Columns.Add("Name");
                dt.Columns.Add("Price");
                dt.Columns.Add("Stock");
                DataRow dr = dt.NewRow(); //Create a new row and add the row values.
                dr[0] = TextBox1.Text;
                dr[1] = TextBox2.Text;
                dr[2] = TextBox3.Text;
                dt.Rows.Add(dr);
                GridView1.DataSource = dt; //Populate values to Gridview.
                GridView1.DataBind();
                Session["Data"] = dt; //Storing that table into session.           
            }
            else
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["Data"]; //Retrieve the stored table from session.
                DataRow dr = dt.NewRow(); //Adding a new row to existing table.
                dr[0] = TextBox1.Text;
                dr[1] = TextBox2.Text;
                dr[2] = TextBox3.Text;
                dt.Rows.Add(dr);
                GridView1.DataSource = dt; //Populate new table values to Gridview.
                GridView1.DataBind();
                Session.Remove("Data"); //Clear the session.
                Session["Data"] = dt; //Store the new table to the session.
            }
        }
