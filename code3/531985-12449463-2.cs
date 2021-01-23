    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using Application = Microsoft.Office.Interop.Word.Application;
    
    namespace WordDocStats
    {
        class Program
        {
            // General idea is based on: https://stackoverflow.com/a/7937590/700926
            static void Main()
            {
                // Open a doc file
                var wordApplication = new Application();
                var document = wordApplication.Documents.Open(@"C:\Users\Username\Documents\document.docx");
    
                // For each inline shape, export it to a file
                // By inspection you can see that the first inline shape have index 1 ( and not zero as one might expect )
                for (var i = 1; i <= wordApplication.ActiveDocument.InlineShapes.Count; i++)
                {
                    // closure
                    // http://confluence.jetbrains.net/display/ReSharper/Access+to+modified+closure
                    var inlineShapeId = i; 
    
                    // parameterized thread start
                    // https://stackoverflow.com/a/1195915/700926
                    var thread = new Thread(() => SaveInlineShapeToFile(inlineShapeId, wordApplication));
    
                    // STA is needed in order to access the clipboard
                    // https://stackoverflow.com/a/518724/700926
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                }
    
                // Close word
                wordApplication.Quit();
                Console.ReadLine();
            }
    
            // General idea is based on: https://stackoverflow.com/a/7937590/700926
            protected static void SaveInlineShapeToFile(int inlineShapeId, Application wordApplication)
            {
                // Get the shape, select, and copy it to the clipboard
                var inlineShape = wordApplication.ActiveDocument.InlineShapes[inlineShapeId];
                inlineShape.Select();
                wordApplication.Selection.Copy();
    
                // Check data is in the clipboard
                if (Clipboard.GetDataObject() != null)
                {
                    var data = Clipboard.GetDataObject();
    
                    // Check if the data conforms to a bitmap format
                    if (data != null && data.GetDataPresent(DataFormats.Bitmap))
                    {
                        // Fetch the image and convert it to a Bitmap
                        var image = (Image) data.GetData(DataFormats.Bitmap, true);
                        var currentBitmap = new Bitmap(image);
    
                        // Save the bitmap to a file
                        currentBitmap.Save(@"C:\Users\Username\Documents\" + String.Format("img_{0}.png", inlineShapeId));
                    }
                }
            }
        }
    }
