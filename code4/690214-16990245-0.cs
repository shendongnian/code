    class Start
    {
        public static void Main()
        {
            // Open a doc file.
            Application application = new Application();
            Document document = application.Documents.Open(@"C:\Users\mmonkan\Documents\word.docx");
            Paragraphs paragraphs = document.Paragraphs;
            Paragraph paragraph = paragraphs[1];
            Range range = paragraph.Range;
            range.SetRange(0, 0);
            range.Paragraphs.TabStops.Add(28, WdTabAlignment.wdAlignTabRight);
            range.Paragraphs.TabStops.Add(56, WdTabAlignment.wdAlignTabRight);
            // Close word.
            application.Quit(WdSaveOptions.wdSaveChanges);
            Console.ReadLine();
        }
    }
