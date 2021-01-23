    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using Application = Microsoft.Office.Interop.Word.Application;
    namespace WordDocStats
    {
        class Program
        {
            // General idea is based on: http://stackoverflow.com/a/7937590/700926
            static void Main()
            {
                // Open a doc file
                var wordApplication = new Application();
                var document = wordApplication.Documents.Open(@"C:\Users\Username\Documents\document.docx");
            
                // Load the image to compare against.
                var bitmapToCompareAgainst = new Bitmap(@"C:\Users\Username\Documents\image.png");
                // For each inline shape, do a comparison
                // By inspection you can see that the first inline shape have index 1 ( and not zero as one might expect )
                for (var i = 1; i <= wordApplication.ActiveDocument.InlineShapes.Count; i++)
                {
                    // closure
                    // http://confluence.jetbrains.net/display/ReSharper/Access+to+modified+closure
                    var inlineShapeId = i; 
                    // parameterized thread start
                    // http://stackoverflow.com/a/1195915/700926
                    var thread = new Thread(() => CompareInlineShapeAndBitmap(inlineShapeId, bitmapToCompareAgainst, wordApplication));
                    // STA is needed in order to access the clipboard
                    // http://stackoverflow.com/a/518724/700926
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                }
                // Close word
                wordApplication.Quit();
                Console.ReadLine();
            }
            // General idea is based on: http://stackoverflow.com/a/7937590/700926
            protected static void CompareInlineShapeAndBitmap(int inlineShapeId, Bitmap bitmapToCompareAgainst, Application wordApplication)
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
                        var image = (Image)data.GetData(DataFormats.Bitmap, true);
                        var currentBitmap = new Bitmap(image);
                        var imagesAreEqual = true;
                        // Compare the images - first by size and then pixel by pixel
                        // Based on: http://www.c-sharpcorner.com/uploadfile/prathore/image-comparison-using-C-Sharp/
                        if(currentBitmap.Width == bitmapToCompareAgainst.Width && currentBitmap.Height == bitmapToCompareAgainst.Height)
                        {
                            for (var i = 0; i < currentBitmap.Width; i++)
                            {
                                if(!imagesAreEqual)
                                    break;
                                for (var j = 0; j < currentBitmap.Height; j++)
                                {
                                    if (currentBitmap.GetPixel(i, j).Equals(bitmapToCompareAgainst.GetPixel(i, j)))
                                        continue;
                                
                                    imagesAreEqual = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            imagesAreEqual = false;
                        }
                        Console.WriteLine("Inline shape #{0} is equal to the 'external' bitmap: {1}", inlineShapeId, imagesAreEqual);
                    }
                    else
                    {
                        Console.WriteLine("Clipboard data is not in an image format");
                    }
                }
                else
                {
                    Console.WriteLine("Clipboard is empty");
                }
            }
        }
    }
