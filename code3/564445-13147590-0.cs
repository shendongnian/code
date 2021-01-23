    private void btn_SaveFile_Click(object sender, RibbonControlEventArgs e) 
    {
       string filePath = defaultPath;
    
       if (subject != "xyz") 
       {
          using(MyPopup popup = new MyPopup())
          {
             // user can close popup - handle this case
             if (popup.ShowDialog() != DialogResult.OK)
                 return;
             filePath = popup.FilePath;
          }
       }       
    
       SaveEmailToText(filePath);
    }
    
    private void SaveEmailToText(string filePath) 
    {
       //other code
       textFile.Save();
    }
