    using System;
    using Microsoft.Office.Interop.Word;
    namespace WordDocStats
    {
        class Program
        {
            // Based on: http://www.dotnetperls.com/word
            static void Main(string[] args)
            {
                // Open a doc file.
                var application = new Application();
                var document = application.Documents.Open(@"C:\Users\MyName\Documents\word.docx");
                // Get the page count.
                var numberOfPages = document.ComputeStatistics(WdStatistic.wdStatisticPages, false);
                // Print out the result.
                Console.WriteLine(String.Format("Total number of pages in document: {0}", numberOfPages));
                // Close word.
                application.Quit();
            }
        }
    }
