    private bool UserExist(string username)
    {
        using (var con = new SqlConnection("..."))
        {
            con.Open();
            using (var cmd = new SqlCommand("...", con))
            {
                using (var r = cmd.ExecuteReader())
                {
                    return r.HasRows;
                }
            }
        }
    }
