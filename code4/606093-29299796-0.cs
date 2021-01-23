        try
        {
            string filePath = this.Application.ActiveDocument.FullName.ToString();
            string fileName = this.Application.ActiveDocument.Name;
            //dialogFilePath = filePath;
            dialogFileName = fileName;
            
            string tempFile;
            string tempPath;
           
            if (true) 
            {
               
                var confirmResult = System.Windows.Forms.MessageBox.Show("Are you sure to save this document ??",
                        "Confirm Save!!",
                        System.Windows.Forms.MessageBoxButtons.YesNo);
                if (confirmResult == System.Windows.Forms.DialogResult.Yes)
                {
                    //document.Save();
                    var iPersistFile = (IPersistFile)document;
                    iPersistFile.Save(tempPath, false);
                   //Do some action here 
                }
                Word._Document wDocument = Application.Documents[fileName] as Word._Document;
                //wDocument.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                ThisAddIn.doc.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
            }
           
        }
        catch (Exception exception)
        {
            
        }
    }
