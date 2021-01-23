    System.EnterpriseServices.Internal.Publish p = new System.EnterpriseServices.Internal.Publish();
    FolderBrowserDialog fb = new FolderBrowserDialog();
    fb.ShowDialog();
    string pathToDll = fb.SelectedPath;
    string excel = t + @"\" + "Microsoft.Office.Interop.Excel.dll";
    
    if (!File.Exists(excel))
    {
        using (FileStream fs = new FileStream(excel, FileMode.CreateNew))
        {
            fs.Write(Properties.Resources.microsoft_office_interop_excel_11, 0, Properties.Resources.microsoft_office_interop_excel_11.Length);
            fs.Close();
        }
     }
     
     Console.WriteLine("Register GAC...");
     p.GacInstall(excel);
