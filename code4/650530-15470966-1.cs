    private void btnBenutz_Click(object sender, EventArgs e)
    {
       lblAusgabe2.Text = "";
       ListBox.ObjectCollection a = listBox1.Items;
       List<string> fileNameList = new List<string>();
       foreach (string x in a)
       {
            fileNameList.Add(x);
            lblAusgabe2.Text += "\n" + x;
       }
       foreach (string b in fileNameList)
       {
           System.Diagnostics.Process.Start("XCOPY.EXE", "/E /I /Y" + b + pfadauswahl + "\\Backup\\" + dt.ToString("yyyy-MM-dd") + "\\UserData\\");
       }
     }
  
     
