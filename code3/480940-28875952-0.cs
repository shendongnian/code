            // Make sure to exit app first
            object saveOption = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
            object originalFormat = Microsoft.Office.Interop.Word.WdOriginalFormat.wdOriginalDocumentFormat;
            object routeDocument = false;
            
            ((_Application)wordApp).Quit(ref saveOption, ref originalFormat, ref routeDocument);
           
            if (wordApp!= null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            
            // Set to null
            wordApp= null;
