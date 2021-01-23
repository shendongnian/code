    progressBar1.Maximum = pathArray.Length;
    progressBar1.Value = 0;
    for (int i = 0; i < pathArray.Length; i++)
    {
    
       string sourcePath = pathArray[i];
  
       progressBar1.Value++;
       if (System.IO.Directory.Exists(sourcePath))
       {                   
          System.IO.Directory.CreateDirectory(targetPathProper);
          string[] subDirs = System.IO.Directory.GetDirectories(sourcePath,"*",(System.IO.SearchOption.AllDirectories))
          progressBar2.Maximum = subDirs.Length;
          progressBar2.Value = 0;
          foreach (string dirPath in subDirs)
          {
             progressBar2.Value++;
             System.IO.Directory.CreateDirectory(dirPath.Replace(sourcePath, 
                targetPathProper));
             Application.DoEvents();
          }
          progressBar2.Value = 0;
          foreach (string newPath in subDirs)
          {
             progressBar2.Value++;
             System.IO.File.Copy(newPath, newPath.Replace(sourcePath, 
                 targetPathProper), true);
             Application.DoEvents();
          }
       } //end if
    } // end for
