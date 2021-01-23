    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label l = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1");
            TextBox t1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
            TextBox t2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
            FileUpload fu = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload1");
    
            string fpath = Server.MapPath("images");
            string fname = fu.FileName;
            string concat = fpath + "\\" + fname;
            fu.SaveAs(concat);
    
            cmd = new SqlCommand("update userdata set username='" + t1.Text + "', password='" + t2.Text + "' , Image = '" + "~/images/"+ fu.FileName + "' where userid='" + Convert.ToInt32(l.Text) + "'", con);
    
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            databind();
        }
