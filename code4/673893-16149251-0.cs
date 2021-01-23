    public void UpdateValues(string accountName)
        {
            OleDbConnection conn = new OleDbConnection(ConnString);
            string sql = @" SELECT * FROM Account where AccountID = '" + accountName + @"'";
            string update = "UPDATE Account SET Cash = ?, PaidInCapital = ?, TotalRetainedEarnings = ?, StockholdersEquity = ?, " +
                            "CommonStock = ?, PreferredStock = ?, TreasuryStock = ?, CashDividends = ?, StockDividends = ?, " +
                            "TotalNumberPreferred = ?, PreferredMarketPrice = ?, PreferredPar = ?, Cumulative = ?, TotalNumberCommon = ?, " +
                            "CommonMarketPrice = ?, CommonPar = ?, NumberTransactTreasuryStock = ?, AvgPriceTreasury = ? WHERE AccountID = '" + accountName + "'";
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = new OleDbCommand(sql, conn);
                AccountDatabaseDataSet ds = new AccountDatabaseDataSet();
                da.Fill(ds, "Account");
                DataTable dt = ds.Tables["Account"];
                dt.Rows[0][1] = cash;
                dt.Rows[0][2] = paidInCapital;
                dt.Rows[0][3] = totalRetainedEarnings;
                dt.Rows[0][4] = stockholdersEquity;
                dt.Rows[0][5] = commonStock;
                dt.Rows[0][6] = preferredStock;
                dt.Rows[0][7] = treasuryStock;
                dt.Rows[0][8] = cashDividends;
                dt.Rows[0][9] = stockDividends;
                dt.Rows[0][10] = totalNumberPreferred;
                dt.Rows[0][11] = preferredMarketPrice;
                dt.Rows[0][12] = preferredPar;
                dt.Rows[0][13] = preferredRate;
                dt.Rows[0][14] = cumulative;
                dt.Rows[0][15] = totalNumberCommon;
                dt.Rows[0][16] = commonMarketPrice;
                dt.Rows[0][17] = commonPar;
                dt.Rows[0][18] = numberTransactTreasury;
                dt.Rows[0][19] = avgPriceTreasury;
                OleDbCommand cmd = new OleDbCommand(update, conn);
                cmd.Parameters.Add("@Cash", OleDbType.Decimal, 18, "Cash");
                cmd.Parameters.Add("@PaidInCapital", OleDbType.Decimal, 18, "PaidInCapital");
                cmd.Parameters.Add("@TotalRetainedEarnings", OleDbType.Decimal, 18, "TotalRetainedEarnings");
                cmd.Parameters.Add("@StockholdersEquity", OleDbType.Decimal, 18, "StockholdersEquity");
                cmd.Parameters.Add("@CommonStock", OleDbType.Decimal, 18, "CommonStock");
                cmd.Parameters.Add("@PreferredStock", OleDbType.Decimal, 18, "PreferredStock");
                cmd.Parameters.Add("@TreasuryStock", OleDbType.Decimal, 18, "TreasuryStock");
                cmd.Parameters.Add("@CashDividends", OleDbType.Decimal, 18, "CashDividends");
                cmd.Parameters.Add("@StockDividends", OleDbType.Decimal, 18, "StockDividends");
                cmd.Parameters.Add("@TotalNumberPreferred", OleDbType.Integer, 16, "TotalNumberPreferred");
                cmd.Parameters.Add("@PreferredMarketPrice", OleDbType.Decimal, 10, "PreferredMarketPrice");
                cmd.Parameters.Add("@PreferredPar", OleDbType.Decimal, 10, "PreferredPar");
                cmd.Parameters.Add("@PreferredRate", OleDbType.Decimal, 5, "PreferredRate");
                cmd.Parameters.Add("@Cumulative", OleDbType.Boolean, 2, "Cumulative");
                cmd.Parameters.Add("@TotalNumberCommon", OleDbType.Integer, 16, "TotalNumberCommon");
                cmd.Parameters.Add("@CommonMarketPrice", OleDbType.Decimal, 10, "CommonMarketPrice");
                cmd.Parameters.Add("@CommonPar", OleDbType.Decimal, 10, "CommonPar");
                cmd.Parameters.Add("@NumberTransactTreasuryStock", OleDbType.Integer, 16, "NumberTransactTreasuryStock");
                cmd.Parameters.Add("@AvgPriceTreasury", OleDbType.Decimal, 10, "AvgPriceTreasury");
                da.UpdateCommand = cmd;
                da.Update(ds, "Account");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Exception Details");
            }
            finally
            {
                conn.Close();
            }
        }
