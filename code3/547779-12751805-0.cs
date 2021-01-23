    using System;
    using System.IO;
    using Microsoft.Office.Interop.Word;
    using Application = Microsoft.Office.Interop.Word.Application;
    
    namespace StackOverflowWordInterop
    {
        class Program
        {
            static void Main()
            {
                // Open word and a docx file
                var wordApplication = new Application() { Visible = true };
                var document = wordApplication.Documents.Open(@"C:\Users\myUserName\Documents\document.docx", Visible: true);
    
                // "10" is chosen by random - select a value that fits your purpose
                for (var i = 0; i < 10; i++)
                {
                    // Insert text
                    var pText = document.Paragraphs.Add();
                    pText.Format.SpaceAfter = 10f;
                    pText.Range.Text = String.Format("This is line #{0}", i);
                    pText.Range.InsertParagraphAfter();
    
                    // Insert table
                    var pTable = document.Paragraphs.Add();
                    pTable.Format.SpaceAfter = 10f;
                    var table = document.Tables.Add(pTable.Range, 2, 3, WdDefaultTableBehavior.wdWord9TableBehavior);
                    for (var r = 1; r <= table.Rows.Count; r++)
                        for (var c = 1; c <= table.Columns.Count; c++)
                            table.Cell(r, c).Range.Text = String.Format("This is cell {0} in table #{1}", String.Format("({0},{1})", r,c) , i);
    
                    // Insert picture
                    var pPicture = document.Paragraphs.Add();
                    pPicture.Format.SpaceAfter = 10f;
                    document.InlineShapes.AddPicture(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "img_1.png"), Range: pPicture.Range);
                    
                }
    
                // Some console ascii-UI
                Console.WriteLine("Press any key to save document and close word..");
                Console.ReadLine();
    
                // Save settings
                document.Save();
    
                // Close word
                wordApplication.Quit();
            }
        }
    }
