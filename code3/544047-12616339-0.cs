    System.Data.DataTable table = new System.Data.DataTable();
    table.Columns.Add("file name");
    table.Columns.Add("data");
    	
    byte[] stream = System.IO.File.ReadAllBytes("th.exe");
    table.Rows.Add("th.exe", stream);
    System.IO.FileStream save = new System.IO.FileStream((string)table.Rows[0].ItemArray[0], System.IO.FileMode.Create);
    byte[] data = (byte[])table.Rows[0].ItemArray[0];
    save.Write(data, 0, data.Length);
