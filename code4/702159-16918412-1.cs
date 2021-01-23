    using System;
    using Microsoft.Office.Interop.Word;
    class Program
    {
        static void Main()
        {
            // Open a doc file.
            Application application = new Application();
            Document document = application.Documents.Open("C:\\word.doc");
            // Loop through all words in the document.
            int count = document.Words.Count;
            for (int i = 1; i <= count; i++)
            {
                // Write the word.
                string text = document.Words[i].Text;
                Console.WriteLine("Word {0} = {1}", i, text);
            }
            // Close word.
            application.Quit();
        }
    }
