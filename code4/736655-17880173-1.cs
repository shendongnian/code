    var sql as new StringBuilder();
    sql.Append("SELECT ... all your columns ... FROM yourTable");
    var parameters as new List(Of SqlParameter);
    if (!string.IsNullOrEmpty(paraCategory)
    {
      sql.Append("[Category]=@Category,");
      parameters.AddWithvalue("@Category", paraCategory);
    }
    sql.Length -= 1
    //...your other parameters...
    sql.Append("ORDER BY CreatedDate");
