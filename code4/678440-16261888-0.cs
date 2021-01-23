        cn.Open();
        SqlCommand cm = new SqlCommand("select * from ImageCollection where img_id='" + DropDownList1.SelectedItem.ToString() + "'", cn);
        SqlDataAdapter da = new SqlDataAdapter(cm);
        SqlDataReader dr = cm.ExecuteReader();
        try
        {
            if (dr.Read())
            {
 
                string image1 = Convert.ToString(DateTime.Now.ToFileTime());
                FileStream fs1 = new FileStream(image1, FileMode.CreateNew, FileAccess.Write);
                byte[] bimage1 = (byte[])dr["passport_photo"];
                fs1.Write(bimage1, 0, bimage1.Length - 1);
                fs1.Flush();
                Image1.ImageUrl = "~/images/"+DropDownList1.SelectedItem.ToString();
            }
            dr.Close();
            cn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
