    if(!IsPostBack)
    {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(" ");
            string consultaComboIdCompra = "SELECT DISTINCT IdCompra FROM Compras";
            SqlCommand sqlCommandComboIdCompra = new SqlCommand(consultaComboIdCompra, sqlConnection);
            sqlConnection.Open();
            SqlDataReader readerComboIdCompra = sqlCommandComboIdCompra.ExecuteReader();
            if (readerComboIdCompra.HasRows)
            {
                while (readerComboIdCompra.Read())
                {
                    DropDownList1.Items.Add(readerComboIdCompra.GetString(0));
                }
            }
            sqlConnection.Close();
    }
