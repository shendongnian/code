        private void cb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            
         
                DataTable mydt = new DataTable();
                try
                {
                    mydt = request.GetItem(int.Parse(cb_category.SelectedValue.ToString()));
                }
                catch { }
                if(mydt.Rows.Count>0)
                {
                cb_Item.DataSource = mydt;
                cb_Item.DisplayMember = "dispmember";
                cb_Item.ValueMember = "valmember";
                }
                else
                {
                    cb_Item.DataSource = null;
                }       
  
        }
