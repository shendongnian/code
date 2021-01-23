       protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e) {
            if (e.RowType != GridViewRowType.Data) return;                    
                e.Row.BackColor = System.Drawing.Color.LightCyan; // Changes The BackColor of ENTIRE ROW
                e.Row.ForeColor = System.Drawing.Color.DarkRed; // Change the Font Color of ENTIRE ROW
        }
