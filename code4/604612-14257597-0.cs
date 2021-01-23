    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Word;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main()
            {
                var app = new Application();
                var doc = app.Documents.Open(@"C:\temp\Foo.docx");
    
                var shapes = doc.Shapes;
    
                foreach (Shape shape in shapes)
                {
                    var initialText = shape.TextFrame.TextRange.Text;
                    var resultingText = initialText.Replace("Foobar", "Woo");
                    shape.TextFrame.TextRange.Text = resultingText;
                }
                doc.Save();
                doc.Close();
    
                Marshal.ReleaseComObject(app);
            }
        }
    }
