    .....
    // Build the command just one time, outside the loop,
    // make it point to the stored procedure above
    cmd = new SqlCommand("UpsertWords", con);
    cmd.CommandType = CommandType.StoredProcedure;                    
    // Create dummy parameters, the actual value is supplied inside the loop
    cmd.Parameters.AddWithValue("@word", string.Empty);
    cmd.Parameters.AddWithValue("@file", string.Empty);
    // Now loop on every file
    for (i = 0; i < files.Length; i++)
    {
        // Open and read all the lines in the current file
        string[] lines = File.ReadAllLines(files[i]);
        // Get only the filename part without the extension
        string fname = Path.GetFileNameWithoutExtension(files[i])
        
        // In case of just one line per file, this loop will execute just one time
        // however we also could handle more than one line per file
        foreach(string line in lines)
        {
            // Set the actual value of the parameters created outside the loop
            cmd.Parameters["@word"] = line;
            cmd.Parameters["@file"] = fname;
            // Run the insert or update (the logic is inside the storedprocedure)
            cmd.ExecuteNonQuery();
        }
