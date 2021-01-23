       foreach (GridViewRow row in GridView1.Rows)
    {
        CheckBox checkbox1 = (CheckBox)row.FindControl("checkboxdelete");
        if (checkbox1.Checked)
        {
            int (primrary key) = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value.ToString());
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("delete from student where Primrarykey = @Primrarykey ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("Primrarykey", SqlDbType.Int).Value = Primrarykey.ToString();
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }
    }
    grdview_bnd();
    }
