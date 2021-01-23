    using(SqlCeConnection sc = new SqlCeConnection(
        SalesTracker.Properties.Settings.Default.salesTrackerConnectionString))
    using(SqlCeCommand cmd = new SqlCeCommand(
        "INSERT INTO Sales VALUES(@itmId, @itmNm,@fstNm, @date,@prft, @commision)",
        sc))
    {
        cmd.Parameters.AddWithValue("@itmId", workingItem.ItemId);
        cmd.Parameters.AddWithValue("@itmNm", workingItem.ItemName);
        cmd.Parameters.AddWithValue("@fstNm", logedSalesmen.ID);
        cmd.Parameters.AddWithValue("@date",
            DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        cmd.Parameters.AddWithValue("@prft", workingItem.Profit);
        cmd.Parameters.AddWithValue("@commision", workingItem.Commision);
        sc.Open();
        cmd.ExecuteNonQuery();
    }
