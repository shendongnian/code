     foreach (GridViewRow row in gv.Rows)
        {
            TextBox txt = row.Cells[0].Controls[0].FindControl("TextBox1") as TextBox;
            string value = txt.Text;
            Response.Write(value);
        }
