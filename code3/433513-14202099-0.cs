    using System;
    using Microsoft.Office.Interop.Word;
    
    namespace WordStack
    {
        public class Program
        {
            private static void Main()
            {
                // Create a new Word application instance (and keep it invisible)
                var wordApplication = new Application() { Visible = false };
    
                // A document must be loaded
                var myDocument = wordApplication.Documents.Open(@"C:\...\myDoc.docx");
    
                // Set the language
                var language = wordApplication.Languages[WdLanguageID.wdEnglishUS];
    
                // Set the filename of the custom dictionary
                // -- Based on:
                // http://support.microsoft.com/kb/292108
                // http://www.delphigroups.info/2/c2/261707.html
                const string custDict = "custom.dic";
    
                // Get the spelling suggestions
                var suggestions = wordApplication.GetSpellingSuggestions("overfloww", custDict, MainDictionary: language.Name);
    
                // Print each suggestion to the console
                foreach (SpellingSuggestion spellingSuggestion in suggestions)
                    Console.WriteLine("Suggested replacement: {0}", spellingSuggestion.Name);
    
                Console.ReadLine();
                wordApplication.Quit();
            }
        }
    }
