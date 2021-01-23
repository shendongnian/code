    //... your code ...
    Task ItmTask = new Task.Factory.StartNew(()=> 
        {
            Task[] subTasks = new Task[arasDefinitionFileCount];
    
            for (int i = 0; i < arasDefinitionFileCount; i++)
            {
                //... your code...
    
                if (ItemType.Equals("Document", StringComparison.InvariantCultureIgnoreCase))
                {
                    subTasks[i] = new Task.Factory.StartNew(() =>
                        {
                            processDocumentDataDefinitionFile(fileName, folderPath + "\\ARAS_IT-" + ItemType + "-files\\");
    
                        });
                }
                else
                {
                    subTasks[i] = new Task.Factory.StartNew(() =>
                        {
                           processDataDefinitionFile(fileName, tbRootFolderPath.Text, ItemType, folderPath + "\\ARAS_IT-" + ItemType + "-files\\");
    
                        });
                }
            }
             // Continue when all sub tasks are done
            Task.Factory.ContinueWhenAll(subTasks, _ => 
             {
                // Cursor.Current = Cursors.WaitCursor;
            
                // .... your code ....
            
                Task[] subTasks2 = new Task[arasDefinitionFileCount];
            
                for (int i = 0; i < arasDefinitionFileCount; i++)
                {
                    subTasks2[i] = new Task.Factory.StartNew(() =>
                    {
                        processDataDefinitionFile(fileName, tbRootFolderPath.Text, ItemType, folderPath + "\\ARAS_IT-" + ItemType + "-files\\");
    
                    });
    
                }
            
                Task.Factory.ContinueWhenAll(subTasks2, __ => 
                  {
                     // reset cursor to normal etc.
                  });
             });
         });
