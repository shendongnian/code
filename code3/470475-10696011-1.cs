        //if (TextBox2.Text == TextBox3.Text)
        //{
            string a;
            a = "insert into tbl_Purchase_Users(Login_Name,Password,Uname,Uid,EmailID,Role,Status) values(@LName,@Pswd,@Uname,@uid,@Eid,@role,@stat)";
            SqlCommand cm = new SqlCommand(a, con1);
            con1.Open();
            cm.Parameters.AddWithValue("@LName", TextBox1.Text);
            string original;
            original = TextBox2.Text.Trim();
            int h = original.GetHashCode();
            string withHash = original;
            b1 = Encoding.BigEndianUnicode.GetBytes(withHash);
            encrypted = Convert.ToBase64String(b1);
            cm.Parameters.AddWithValue("@Pswd", encrypted);
            cm.Parameters.AddWithValue("@Uname", TextBox3.Text);
            cm.Parameters.AddWithValue("@uid", TextBox4.Text);
            cm.Parameters.AddWithValue("@Eid", TextBox5.Text);
            cm.Parameters.AddWithValue("@role", TextBox6.Text);
            cm.Parameters.AddWithValue("@stat", TextBox7.Text);
            cm.ExecuteNonQuery();
            Response.Write("<Script>alert('inserted')</script>");
            con1.Close();
}
