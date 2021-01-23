    private List<System.Drawing.Color> BuildColorList()
    {
        List<System.Drawing.Color>ColorList = new List<System.Drawing.Color>();
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("select color from Colors", con))
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    System.Drawing.Color color = System.Drawing.Color.FromName((string)rdr["color"]);
                    ColorList.Add(color);
                }
            }
            return ColorList;
        }
    }
