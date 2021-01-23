    SqlParameter id = new SqlParameter("@bookId", System.Data.SqlDbType.Int);
    id.Direction = System.Data.ParameterDirection.Output;
    cmd.Parameters.Add(id);
    cmd.ExecuteNonQuery();
    Int32.TryParse(id.Value.ToString(),out book.BookId);
