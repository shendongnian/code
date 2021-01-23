    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Word;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main()
            {
                const string documentLocation = @"C:\temp\Foo.docx";
                const string findText = "Foobar";
                const string replaceText = "Woo";
    
                FindReplace(documentLocation, findText, replaceText);
            }
    
            private static void FindReplace(string documentLocation, string findText, string replaceText)
            {
                var app = new Application();
                var doc = app.Documents.Open(documentLocation);
    
                var range = doc.Range();
    
                range.Find.Execute(FindText: findText, Replace: WdReplace.wdReplaceAll, ReplaceWith: replaceText);
    
                var shapes = doc.Shapes;
    
                foreach (Shape shape in shapes)
                {
                    var initialText = shape.TextFrame.TextRange.Text;
                    var resultingText = initialText.Replace(findText, replaceText);
                    shape.TextFrame.TextRange.Text = resultingText;
                }
    
                doc.Save();
                doc.Close();
    
                Marshal.ReleaseComObject(app);
            }
        }
    }
