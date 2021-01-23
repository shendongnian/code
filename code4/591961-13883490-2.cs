    namespace StackWord
    {
        using StackWord = Microsoft.Office.Interop.Word;
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var myWord = new StackWord.Application { Visible = true };
                var myDoc = myWord.Documents.Add();
                var myParagraph = myDoc.Paragraphs.Add();
                myParagraph.Range.Text = 
                   "Example test one\rExample two\rExample three\r";
                
                foreach (StackWord.Range range in myWord.ActiveDocument.StoryRanges)
                {
                    range.Find.Text = "\r";
                    range.Find.Replacement.Text = "\r\r\r\r";
                    range.Find.Wrap = StackWord.WdFindWrap.wdFindContinue;
                    object replaceAll = StackWord.WdReplace.wdReplaceAll;
                    if (range.Find.Execute(Replace: ref replaceAll))
                    {
                        Console.WriteLine("Found and replaced.");
                    }
                }
                Console.WriteLine("Press any key to close...");
                Console.ReadKey();
                myWord.Quit();
    
            }
        }
    }
