       Task<List<newFile>> task1 = Task<List<newFile>>.Factory.StartNew(() =>
       {
          List<newFile> newFiles; = new List<newFile>();
         foreach(string file in fileList)
         {
            newFiles.Add(SendFilesToConvert(file));
         }
         return newFilesList;
       }
    
       task1.Wait()
       foreach(newFile nFile in task1.Result)
       {
         listBoxFiles.Items.Add(nFile);
       }
