     try this
    
     protected void Button1_Click(object sender, EventArgs e) {
             var query2 =  from cm in DC.custMasts where cm.custCity == TextBox1.Text.Trim()
              select new {
                    Name=cm.custName, 
                   City=cm.cmcustCity, 
                    Company=cm.custCompany
                }.ToList();
            GridView1.DataSource  = query2 ;   GridView1.DataBind();
     
     }
