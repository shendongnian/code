    for (i = 0; i < files.Length; i++)
    {
        string[] lines = File.ReadAllLines(files[i]);
        string fname = Path.GetFileNameWithoutExtension(files[i])
        cmd = new SqlCommand("UpsertWords", con);
        cmd.CommandType = CommandType.StoredProcedure;                    
        cmd.Parameters.AddWithValue("@word", string.Empty);
        cmd.Parameters.AddWithValue("@file", string.Empty);
        foreach(string line in lines)
        {
            cmd.Parameters["@word"] = line;
            cmd.Parameters["@file"] = fname;
            cmd.ExecuteNonQuery();
        }
