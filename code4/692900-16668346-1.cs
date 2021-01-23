    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label EmpID = new Label();
        EmpID = (Label)GridView1.Rows[e.RowIndex].Cells[2].FindControl("EmpID");
        cmd = new SqlCommand("delete from salesman_setails where EmpID=" + EmpID.Text + "", con);
        using( con = new SqlConnection(strConnection))
        {
            con.Open();
            int k = cmd.ExecuteNonQuery();
            con.Close();
            if (k == 1)
            {
                Response.Write("<script>alert('Employee Deleted Successfully')</script>");
                BindGrid();
            }
            else
            {
                Response.Write("<script>alert('Error Occured While Deleting')</script>");
                BindGrid();
            }
        }
    }
