        Microsoft.Office.Interop.Word.ProofreadingErrors errorCollection = null;
        try
        {
            errorCollection = Globals.ThisAddIn.Application.ActiveDocument.SpellingErrors;
         // Indexes start at 1 in Office objects
            for (int i = 1; i <= errorCollection .Count; i++)
            {
                int start =  errorCollection[i].Start;
                int end = errorCollection[i].End;
            
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            // Release the COM objects here 
            // as finally shall be always called
            if (errorCollection != null)
            {
                Marshal.ReleaseComObject(errorCollection);
                errorCollection = null;
            }
        }
