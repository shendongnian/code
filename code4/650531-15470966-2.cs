    public void StartXcopy()
    {
           ListBox.ObjectCollection a = listBox1.Items;
           fileNameList = new List<string>();
           foreach (string x in a)
           {
                fileNameList.Add(x);
                lblAusgabe2.Text += "\n" + x;
           }
    
           foreach (string filename in fileNameList)
           {
               System.Diagnostics.Process.Start("XCOPY.EXE", "/E /I /Y" + filename  + pfadauswahl + "\\Backup\\" + dt.ToString("yyyy-MM-dd") + "\\UserData\\");
           }
    }
