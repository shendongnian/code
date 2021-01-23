        string linksfile;
        string [] excelfile = Directory.GetFiles(Application.StartupPath + @"\", "*.xlsx");
        
        if(excelfile.Length > 0)
        {
            linksfile = excelfile[0];
    
            MessageBox.Show(linksfile);
        }
        else
        {
             MessageBox.Show("File not found");
        }
