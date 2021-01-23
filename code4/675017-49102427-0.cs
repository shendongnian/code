    public bool IsConnected() {
        using (var conn = new SqlConnection(DBConnection.ConnectionString)) {
            using (var cmd = New SqlCommand("SELECT 1", conn)) {
                try {
                    conn.Open();
                    cmd.ExecuteScalar();
                    return true;
                } catch (SqlException) {
                    return false;
                }
            }
        }
    }
