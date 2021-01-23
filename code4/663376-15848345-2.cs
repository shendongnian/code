    void WriteFile()
    {
        using (var doc = new Document(PageSize.LETTER))
        {
            using (var fs = new FileStream("test.pdf", FileMode.Create))
            {
                using (var writer = PdfWriter.GetInstance(doc, fs))
                {
                    doc.Open();
                    var blueFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLUE);
                    doc.Add(new Chunk("Go to URL", blueFont).SetAction(new PdfAction("http://www.google.com/", false)));
                    doc.NewPage();
                    doc.Add(new Chunk("Go to Test", blueFont).SetLocalGoto("entry1"));
                    doc.NewPage();
                    doc.Add(new Chunk("Test").SetLocalDestination("entry1"));
                    doc.Close();
                }
            }
        }
    }
