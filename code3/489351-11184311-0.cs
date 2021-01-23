     con.Open();
                string a;
                a = "insert into tbl_KKSUser(EName,Uname,Password)values(@en,@un,@pas)";
                SqlCommand cm = new SqlCommand(a, con);
                SqlParameter paramName;
                paramName = new SqlParameter("@en", SqlDbType.VarChar, 25);
                paramName.Value = DropDownList1.SelectedItem.Text;
                cm.Parameters.Add(paramName);
        
                string original = TextBox2.Text.Trim();
                int h = original.GetHashCode();
                string withHash = original;
                b1 = Encoding.BigEndianUnicode.GetBytes(withHash);
                encrypted = Convert.ToBase64String(b1);
                SqlParameter paramPass;
                paramPass = new SqlParameter("@pas", SqlDbType.VarChar, 300);
                paramPass.Value = Convert.ToString(encrypted);
                cm.Parameters.Add(paramPass);
        
                cm.ExecuteNonQuery(); // here call ExecuteNonQuery
        
                Response.Write("<script>alert('inserted')</alert>");
                con.Close();
