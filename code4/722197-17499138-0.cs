        public void CharacterSpacingTest()
        {
            float margin = 50;
            using (var stream = new MemoryStream())
            {
                Document document = new Document();
                document.SetPageSize(new Rectangle(PageSize.A4.Width, PageSize.A4.Height));
                document.SetMargins(margin, margin, 30f, 100f);
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
                writer.CloseStream = false;
                document.Open();
                PdfPTable table = new PdfPTable(new float[] { 100 });
                table.TotalWidth = PageSize.A4.Width - margin - margin;
                table.WidthPercentage = 100f;
                table.LockedWidth = true;
                // Create a row that is right aligned
                PdfPCell cell1 = new PdfPCell();
                cell1.AddElement(new Paragraph(GetChunk("Hello World")) { Alignment = Element.ALIGN_RIGHT });
                cell1.BorderWidth = 1;
                table.AddCell(cell1);
                // Create a row that is left aligned
                PdfPCell cell2 = new PdfPCell();
                cell2.AddElement(new Paragraph(GetChunk("Hello World")));
                cell2.BorderWidth = 1;
                table.AddCell(cell2);
                document.Add(table);
                document.Close();
                Blobs.SaveToFile(Blobs.LoadFromStream(stream), @"c:\Dev\test.pdf");
            }
        }
        private Chunk GetChunk(string text)
        {
            Chunk chunk = new Chunk(text);
            chunk.SetCharacterSpacing(1);
            return chunk;
        }
