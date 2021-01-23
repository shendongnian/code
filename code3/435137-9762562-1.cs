    class Program {
        static void Main(string[] args) {
            double[,] pt = {
                { 0.3, 0.2, 0.1, 0.8 },
                { 0.2, 0.5, 0.5, 0.1 },
                { 0.1, 0.6, 0.5, 0.2 }
            };
            // Replace SqlConnection with what is specific to your ADO.NET provider / DBMS.
            using (var conn = new SqlConnection("your connection string")) {
                conn.Open();
                using (var cmd = conn.CreateCommand()) {
                    // Construct SQL text (use parameter prefix specific to your DBMS instead of @ as appropriate).
                    var sb = new StringBuilder();
                    for (int y = 0; y < pt.GetLength(0); ++y)
                        for (int x = 0; x < pt.GetLength(1); ++x)
                            sb.Append(
                                string.Format(
                                    "INSERT INTO YOUR_TABLE (INDEX_X, INDEX_Y, VALUE) VALUES (@index_x_{0}_{1}, @index_y_{1}_{1}, @value_{0}_{1});",
                                    x,
                                    y
                                )
                            );
                    cmd.CommandText = sb.ToString();
                    // Bind parameters.
                    for (int y = 0; y < pt.GetLength(0); ++y)
                        for (int x = 0; x < pt.GetLength(1); ++x) {
                            cmd.Parameters.AddWithValue(string.Format("@index_x_{0}_{1}", x, y), x);
                            cmd.Parameters.AddWithValue(string.Format("@index_y_{0}_{1}", x, y), y);
                            cmd.Parameters.AddWithValue(string.Format("@value_{0}_{1}", x, y), pt[y, x]);
                        }
                    // Perform the actual insert.
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
