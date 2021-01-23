    using System;
    using System.Linq;
    using Microsoft.Office.Interop.Word;
    using Application = Microsoft.Office.Interop.Word.Application;
    
    namespace WordDocStats
    {
        internal class Program
        {
            private static void Main()
            {
                var wordApplication = new Application() { Visible = true };
    
                // Open document A
                var documentA = wordApplication.Documents.Open(@"C:\Users\MyUser\Documents\documentA.docx", Visible: true);
    
                // This inserts text in front of each list found in the document
                const string myText = "My Text Before The List";
                foreach (List list in documentA.Lists)
                {
                    // Range of the current list
                    var listRange = list.Range;
    
                    // Range of character before the list
                    var prevRange = listRange.Previous(WdUnits.wdCharacter);
    
                    // If null, the list might be located in the very beginning of the doc
                    if (prevRange == null)
                    {
                        // Insert new paragraph
                        listRange.InsertParagraphBefore();
                        // Insert the text
                        listRange.InsertBefore(myText);
                    }
                    else
                    {
                        if (prevRange.Text.Any())
                        {
                            // Dont't append the list text to any lines that might already be just before the list
                            // Instead, make sure the text gets its own line
                            prevRange.InsertBefore("\r\n" + myText);
                        }
                        else
                        {
                            // Insert the list text
                            prevRange.InsertBefore(myText);
                        }
                    }
                }
                
                // Save, quit, dones
                Console.WriteLine("Dones");
                Console.ReadLine();
                documentA.Save();
                wordApplication.Quit();
            }
        }
    }
