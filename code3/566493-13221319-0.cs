    using Microsoft.Office.Interop.Word;
    using Application = Microsoft.Office.Interop.Word.Application;
    
    namespace WordDocStats
    {
        internal class Program
        {
            private static readonly HashSet<Document> OpenDocuments = new HashSet<Document>();
    
            private static void Main()
            {
                var wordApplication = new Application() { Visible = true };
    
                // Listen for documents open
                wordApplication.DocumentOpen += WordApplicationDocumentOpen;
    
                // Listen for documents close
                wordApplication.DocumentBeforeClose += WordApplicationDocumentBeforeClose;
    
                Console.ReadLine();
                wordApplication.Quit();
            }
    
            static void WordApplicationDocumentBeforeClose(Document doc, ref bool cancel)
            {
                OpenDocuments.Remove(doc);
                Console.WriteLine(doc.Name + " closed!");
            }
    
            static void WordApplicationDocumentOpen(Document doc)
            {
                // If this returns true, the doc is not in the set of open documents, hence the doc is not already open
                if(OpenDocuments.Add(doc))
                {
                    OpenDocuments.Add(doc);
                    Console.WriteLine(doc.Name + " opened...");
                }
                // Otherwise, the doc is already in the set of open documents, hence we know the document is already open
                else
                {
                    Console.WriteLine(doc.Name + " is already open!");
                }
            }
        }
    }
