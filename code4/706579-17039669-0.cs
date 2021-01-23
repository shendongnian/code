    SqlParameter id = new SqlParameter("@bookId", System.Data.SqlDbType.Int);
    id.Direction = System.Data.ParameterDirection.Output;
    cmd.Parameters.Add(id);
    cmd.ExecuteNonQuery();
    book.BookId = (int)id.Value;
