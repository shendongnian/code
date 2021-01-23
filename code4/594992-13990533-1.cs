    using System;
    using System.Linq;
    using Word = Microsoft.Office.Interop.Word;
    
    namespace WordCopy
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fileName = args[0];
    
                var wordApp = new Word.Application();
                wordApp.Visible = true;
                var document = wordApp.Documents.Open(fileName);
    
                var newDocument = CopyToNewDocument(document);
    
                SearchAndReplaceEverywhere(newDocument, "this", "that");
            }
            
            static Word.Document CopyToNewDocument(Word.Document document)
            {
                document.StoryRanges[Word.WdStoryType.wdMainTextStory].Copy();
                
                var newDocument = document.Application.Documents.Add();
                newDocument.StoryRanges[Word.WdStoryType.wdMainTextStory].Paste();
                return newDocument;
            }
    
            static void SearchAndReplaceEverywhere(
                Word.Document document, string find, string replace)
            {
                foreach (Word.Range storyRange in document.StoryRanges)
                {
                    var range = storyRange;
                    while (range != null)
                    {
                        SearchAndReplaceInStoryRange(range, find, replace);
    
                        if (range.ShapeRange.Count > 0)
                        {
                            foreach (Word.Shape shape in range.ShapeRange)
                            {
                                if (shape.TextFrame.HasText != 0)
                                {
                                    SearchAndReplaceInStoryRange(
                                        shape.TextFrame.TextRange, find, replace);
                                }
                            }                        
                        }
                        range = range.NextStoryRange;
                    }
                }
            }
    
            static void SearchAndReplaceInStoryRange(
                Word.Range range, string find, string replace)
            {
                range.Find.ClearFormatting();
                range.Find.Replacement.ClearFormatting();
                range.Find.Text = find;
                range.Find.Replacement.Text = replace;
                range.Find.Wrap = Word.WdFindWrap.wdFindContinue;
                range.Find.Execute(Replace: Word.WdReplace.wdReplaceAll);
            }
        }
    }
