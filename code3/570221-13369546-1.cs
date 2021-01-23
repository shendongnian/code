     protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e) {
    
        if (e.RowType != GridViewRowType.Data) return;       
         int VALUE = Convert.ToInt32(e.GetValue("COLUMNNAME"));
              if (VALUE < 20)          
           {
                    e.Row.BackColor = System.Drawing.Color.LightCyan; // Changes The BackColor of ENTIRE ROW
                    e.Row.ForeColor = System.Drawing.Color.DarkRed; // Change the Font Color of ENTIRE ROW
            }
    }
