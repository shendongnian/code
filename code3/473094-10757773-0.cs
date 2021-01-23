    var sb = new StringBuilder();            
    sb.Append("UPDATE InboxItem ");
    sb.Append("SET OrderId = @0, Item = @1, Quantity = @2, Price = @3, ");
    sb.Append("Memo = @7, InboxId = @4, VATId = @5 ");
    sb.Append("WHERE Id = @6");
    var cm = new SqlCommand(sb.ToString());
    cm.CommandType = System.Data.CommandType.Text;
    cm.Parameters.AddWithValue("@1", Convert.ToInt16("OrderValue"));
    //and so on
