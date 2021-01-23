    using System;
    using Microsoft.Office.Interop.Word;
    class Program
    {
        static void Main()
        {
            var wordToFind = "some_word_to_find";
            var wordCounter = 0;
            // Open a doc file.
            var application = new Application();
            var document = application.Documents.Open("C:\\word.doc");
            // Loop through all words in the document.
            for (var i = 1; i <= document.Words.Count; i++)
                if (document.Words[i].Text.TrimEnd() == wordToFind)
                    wordCounter++;
            Console.WriteLine("Matches Found: {0}", wordCounter);
            // Close word.
            application.Quit();
        }
    }
