    // Using DataTable as a mockup database.
    System.Data.DataTable table = new System.Data.DataTable();
    table.Columns.Add("file name");
    table.Columns.Add("data");
    
    // Read data from file.
    byte[] stream = System.IO.File.ReadAllBytes("th.exe");
    // Add the file to the db, don't know how you add data to your database.
    table.Rows.Add("th.exe", stream);
    // Create a filestream that will write data to disk (in a file).
    System.IO.FileStream save = new System.IO.FileStream((string)table.Rows[0].ItemArray[0], System.IO.FileMode.Create);
    // Retrieve the data from the database, don't know how you do this with your database.
    byte[] data = (byte[])table.Rows[0].ItemArray[0];
    // Write data to the file on disk.
    save.Write(data, 0, data.Length);
