    strPath = txtInputFolder.Text;
    DirectoryInfo di = new DirectoryInfo(strPath);
    FileInfo[] lstFile = di.GetFiles("*.sql");
    string strScriptPath = System.IO.Path.Combine(strPath, lblOutput.Text);
    using (FileStream foutput = System.IO.File.Create(strScriptPath))
    using (StreamWriter writer = new StreamWriter(foutput))
    {
        string strLine;
        foreach (FileInfo fi in lstFile)
        {
            strLine = string.Empty;
            strLine = "\r\n\r\n/*--------- " + fi.Name + " -------------*/" + "\r\n\r\n";
            writer.Write(strLine);
            //some processing
        }
    }
    MessageBox.Show("Done");
