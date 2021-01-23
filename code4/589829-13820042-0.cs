            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandTimeout = 0;
            cmd.CommandText = "hhrcv_upsert_grv_sku";
            cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("pv_delivery_bay_code", OracleDbType.VarChar).Value = this.bayCode.ToString();
        cmd.Parameters.Add("pn_company_id_no", OracleDbType.Number).Value = lblCompany_id_no.Text.ToString();
        cmd.Parameters.Add("pn_order_no", OracleDbType.Number).Value = this.orderCode.ToString();
        cmd.Parameters.Add("pn_sku_id_no", OracleDbType.Number).Value = lblSku_id_no.Text.ToString();
        cmd.Parameters.Add("pn_price", OracleDbType.Number).Value = txtPrice.Text.ToString();
        var pv_error = cmd.Parameters.Add(new OracleParameter("pv_error", OracleDbType.VarChar));
        pv_error.Direction = ParameterDirection.Output;
        conn.Open();
        cmd.ExecuteNonQuery();
        
        if (pv_error.Value.ToString().Equals("Invalid"))
        {
            MessageBox.Show("Invalid");
        }
        else
        {
            MessageBox.Show("valid");
        }
