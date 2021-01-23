    private DataTable CreateDtDocs(string name, string path, FileUpload FileUploader)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("SR_NO");
            dt1.Columns.Add("Name");
            dt1.Columns.Add("Path");
            
            Type col_type = fubrowse.GetType();
            DataColumn dt_col = new DataColumn("Control", col_type);
            
            dt1.Columns.Add(dt_col);
    
            DataRow dr = dt1.NewRow();
            dr["SR_NO"] = "1";
            dr["NAME"] = name;
            dr["Path"] = path;
            dr["Control"] = FileUploader;
            dt1.Rows.Add(dr);
            return dt1;
        }
