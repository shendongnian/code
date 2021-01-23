    using (var conn = <GETCONNECTIONMETHOD>)
    {
       var dt = new DataTable;
       dt.BeginLoadData();
       dt.Columns.Add("id");
       foreach (int id in transactionsToUpdate.ToList() {
         dt.Rows.Add(id);
       }
       dt.EndLoadData();
       using (var cmdSetup = conn.CreateCommand(@"create table #tempUpdate(int id)")) {
          cmdSetup.ExecuteNonQuery();
       }
       var bcp = new SqlBulkCopy(conn);
       bcp.DestinationTableName = "#tempUpdate";
       bcp.WriteToServer(dt);
       using (var cmdUpdate = conn.CreateCommand(
          @"update o set status = 'C' from dbo.outgoingQueue o " +
          @"inner join #tempUpdate t on o.transactionId = t.id"))
       {
          cmd.ExecuteNonQuery();
       }
    }
