    dt.Columns.Add("Paren Folder Name");  
    dt.Columns.Add("File_Name");
    dt.Columns.Add("Version");
    dt.Columns.Add("File_Type");
    dt.Columns.Add("File_Size");
    dt.Columns.Add("Create_Date");
    
    DirectoryInfo directory = new DirectoryInfo(@LocationX);
    foreach(FileInfo file in directory.GetFiles("#", SearchOption.AllDirectories))
    {
        dr = dt.NewRow();
        dr["Root"] = file.Directory.Name; 
        dr["File_Name"] = file.Name;
        dr["File_Type"] = file.Extension;
        dr["File_Size"] = (file.Length / 1024).ToString();
        dr["Create_Date"] = file.CreationTime.Date.ToString("dd/MM/yyyy");
        dt.Rows.Add(dr);
    }
