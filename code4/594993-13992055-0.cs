    using System.Runtime.InteropServices;
    using MSWord = Microsoft.Office.Interop.Word;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main()
            {
                var application = new MSWord.Application();
                var originalDocument = application.Documents.Open(@"C:\whatever.docx");
    
                originalDocument.ActiveWindow.Selection.WholeStory();
                var originalText = originalDocument.ActiveWindow.Selection;
    
                var newDocument = new MSWord.Document();
                newDocument.Range().Text = originalText.Text;
                newDocument.SaveAs(@"C:\whateverelse.docx");
    
                originalDocument.Close(false);
                newDocument.Close();
    
                application.Quit();
    
                Marshal.ReleaseComObject(application);
            }
        }
    }
