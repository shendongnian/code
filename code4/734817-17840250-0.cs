    //... your code ...
    Task ItmTask = new Task.Factory.StartNew(()=> 
        {
            Task subTasks = new Task[arasDefinitionFileCount];
    
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
    
            Task.WaitAll(subTasks); // wait for all sub-tasks to be over.
         });
    
    ItmTask.ContinueWith( ()=> 
        {
            // Cursor.Current = Cursors.WaitCursor;
            
            // .... your code ....
            
            Task subTasks = new Task[arasDefinitionFileCount];
            
            for (int i = 0; i < arasDefinitionFileCount; i++)
            {
                subTasks[i] = new Task.Factory.StartNew(() =>
                {
                    processDataDefinitionFile(fileName, tbRootFolderPath.Text, ItemType, folderPath + "\\ARAS_IT-" + ItemType + "-files\\");
    
                });
    
            }
            
            Task.WaitAll(subTasks);
            
            // reset cursor to normal etc.
    
        });
