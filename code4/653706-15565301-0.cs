    private void btnRefresh_Click_1(object sender, EventArgs e)
    {
        var sb = new StringBuilder("select Party_Code,TradeNo,Scrip_Code,Inst_Type,Expirydate,Strike_price,Option_type,TerminalId,Branch_Id,Buy_Sell,Trade_Qty,Market_Rate,Sauda_Date,OrderNo from tradeFile");
        if (!string.IsNullOrEmpty(txtSearchPartyCode.Text))
            sb.AppendFormat(" where Party_Code='{0}'", txtSearchPartyCode.Text);
        if (!string.IsNullOrEmpty(txtSearchBranchId.Text))
            sb.AppendFormat(" where Branch_Id='{0}'", txtSearchBrandId.Text);
        // ...and so on...
        sb.Append(";");
        try
        {
            da = new SqlDataAdapter(sb.ToString(), con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvTradeFile.DataSource = ds.Tables[0];
        }
        catch(Exception ex)
        {
           MessageBox.Show(ex.Message);
        }
    }
