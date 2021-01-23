    SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (DropDownList1.Items[i].Selected == true)
                {
                    str = "insert into employee1 values('" + DropDownList1.Items[i].ToString() + "')";
                    com = new SqlCommand(str, con);
                    com.ExecuteNonQuery();
                    Response.Write("<script>alert('Items Inserted');</script>");
                }
            }
