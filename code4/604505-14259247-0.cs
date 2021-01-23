        using (Document doc = new Document())
        {
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"mod.pdf", FileMode.Create));
            doc.Open();
            PdfContentByte over = writer.DirectContent;
            over.SaveState();
            over.Rectangle(10, 10, 50, 50);
            over.SetColorFill(BaseColor.BLUE);
            over.Fill();
            PdfGState gs1 = new PdfGState(); 
            gs1.FillOpacity = 0.5f;
            over.SetGState(gs1);
            over.Rectangle(0, 0, 60, 60);
            over.SetColorFill(new BaseColor(255, 0, 0, 150));
            over.Fill();
            over.RestoreState();
            doc.Close();
        }
