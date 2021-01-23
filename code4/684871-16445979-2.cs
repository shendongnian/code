    public Byte[] ShowEmpImage(int empno) {
        string sql = "SELECT CoverPhoto FROM Galleries WHERE GalleryID = @GalleryID";
        Byte[] result = null;
    
        using (SqlConnection conn = new SqlConnection(CodProbs.Main.GetDSN())) {
            using(SqlCommand cmd = new SqlCommand(sql, conn)) {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@GalleryID", empno);
                conn.Open();
                result = (Byte[])cmd.ExecuteScalar();
            }
        }
    
        return result;
    }
