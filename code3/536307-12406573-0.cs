          protected void Page_Load(object sender, EventArgs e)
            {
              if(!Ispostback)
                {
                string select = "select * from courses";
                DropDownList1.Items.Add("-- Select Course --","0");
        
                DataTable dt = con.select_command(select);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList1.Items.Add(new listitem(dt.Rows[i][1].ToString(),dt.Rows[i][0].ToString();
            ));
            
                }        
                    DropDownList1.SelectedIndex = 0;
            }
      }
