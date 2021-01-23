    string fileToCopy = "filelocation\\file_name.txt";
    String server = Environment.UserName;
    string newLocation = "C:\\Users\\" + server + "\\Pictures\\Tenders\\file_name.txt";
    string folderLocation = "C:\\Users\\" + server + "\\Pictures\\Tenders\\";
    bool exists = System.IO.Directory.Exists(folderLocation);
    if (!exists)
    {
       System.IO.Directory.CreateDirectory(folderLocation);
       if (System.IO.File.Exists(fileToCopy))
       {
         MessageBox.Show("file copied");
         System.IO.File.Copy(fileToCopy, newLocation, true);
       
       }
       else
       {
          MessageBox.Show("no such files");
        
       }
    }
