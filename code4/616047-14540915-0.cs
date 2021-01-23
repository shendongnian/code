            MySQLConnection.con.Open();
            read = com.ExecuteReader();
		if(read != null)
		{
			while (read.Read())
			{
			txtCatogery.Text = read["Catogery"].ToString();
			txtDiscriptions.Text = read["Description"].ToString();
			txtQTY.Text = read["QTY"].ToString();
			txtPrice.Text = read["Price"].ToString();
			}
		}
		else
		{
			txtCatogery.Text = "";
			txtDiscriptions.Text =  "";
			txtQTY.Text =  "";
			txtPrice.Text =  "";
		}
