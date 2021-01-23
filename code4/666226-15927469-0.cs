    public void SomeWhereInYourWebServerApplication
        {           
            FileSystemWatcher fsw = new FileSystemWatcher("tempfolder");
            fsw.Created += fsw_Created;
                    
            // save new entries to tempfolder
        }
        
        void fsw_Created(object sender, FileSystemEventArgs e)
        {
          foreach (string file in Directory.GetFiles("tempfolder"))
            {
             try
               {
                string fileText = File.ReadAllText(file);
                File.AppendAllText("myStorage.txt", fileText);
                File.Delete(file);
               }
              catch
               {
                  // for me it's ok when we try to append the file the next time something                                  
                  // new is coming
               }
            }
        } 
  
