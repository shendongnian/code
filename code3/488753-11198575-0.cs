    using (ExcelPackage p = new ExcelPackage(new FileInfo(@"C:\Users_Template_12_22_Template.xlsx")))
    {
        var parts = p.Package.GetParts();
        foreach (var part in parts)
        {
            if (part.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.customProperty")
            {
                using (var stream = part.GetStream())
                {
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, (int)stream.Length);
                    stream.Close();
    
                    string customPropertyInfo = System.Text.Encoding.Unicode.GetString(data);
                }
            }
        }
    }
