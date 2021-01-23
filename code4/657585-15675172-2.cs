    just put like this>>
    
   
     if(dr!=null)
        {
            while (dr.Read())
                {
                    if((dr["perwet"]!=null)||(dr["perwet"].ToString()!=""))
                    TextBox2.Text = dr["perwet"].ToString();
                    else
                    TextBox2.Text="";
            
            
                    //  DropDownList1.Items(DropDownList1.SelectedIndex).Text = dr["service"].ToString();
                }
        }
