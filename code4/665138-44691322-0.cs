     try
            {
                cmd.CommandText = "UPDATE [Sheet1$] SET ID=@value,Name=@value2,Age=@value3 where ID=@value4";
                cn.Open();
                cmd.Parameters.AddWithValue("@value1", txtid.Text);
                cmd.Parameters.AddWithValue("@value2", txtname.Text);
                cmd.Parameters.AddWithValue("@value3", txtage.Text);
                cmd.Parameters.AddWithValue("@value4", txtupdate.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                cn.Close();
            }
            catch (Exception e3)
            {
                MessageBox.Show("Error" + e3);
            }
