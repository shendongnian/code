    using System.Runtime.InteropServices;
    using MSWord = Microsoft.Office.Interop.Word;
    
    namespace ResetNumberingInWordDoc
    {
        class Program
        {
            static void Main()
            {
                var application = new MSWord.Application();
                var document = application.Documents.Open(@"C:\mydocument.docx");
    
                const int listNumber = 1; //The first list on the page is list 1, the second is list 2 etc etc
                
                document.Range().ListFormat.ApplyListTemplateWithLevel(
                    ListTemplate: document.ListTemplates[listNumber], 
                    ContinuePreviousList: false, 
                    ApplyTo: MSWord.WdListApplyTo.wdListApplyToWholeList,
                    DefaultListBehavior: MSWord.WdDefaultListBehavior.wdWord10ListBehavior);
    
                document.Save();
                document.Close();
    
                application.Quit();
    
                Marshal.ReleaseComObject(application);
            }
        }
    }
