         private void button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\Test.pdf", FileMode.Create));
            doc.Open();
            Paragraph paragraph = new Paragraph("Hi, \n This is xxx from yyy \n This is my pdf file");
            doc.Add(paragraph);
            doc.Close();
        }
