            PDFNet.Initialize();
            // Relative path to the folder containing test files.
            string input_path = "../../../../TestFiles/";
            string output_path = "../../../../TestFiles/Output/";
            PDFDoc doc = new PDFDoc(input_path + "form1.pdf");
            ElementWriter writer = new ElementWriter();
            ElementBuilder eb = new ElementBuilder();
            for (int index = 1; index <= doc.GetPageCount(); index++)
            {
                Page page = doc.GetPage(index); 
                writer.Begin(page);
                eb.Reset();
                
                // Begin writing a block of text
                string data = "Page " + index;
                Element element = eb.CreateTextBegin(Font.Create(doc, Font.StandardType1Font.e_times_roman, true), 10.0);
                writer.WriteElement(element);
                eb.CreateTextRun(data);
                element.SetTextMatrix(10, 0, 0, 10, 100, 100);
                GState gstate = element.GetGState();
                gstate.SetTextRenderMode(GState.TextRenderingMode.e_fill_text);
                gstate.SetStrokeColorSpace(pdftron.PDF.ColorSpace.CreateDeviceRGB());
                gstate.SetStrokeColor(new pdftron.PDF.ColorPt(1, 0, 0));
                writer.WriteElement(element);
                writer.WriteElement(eb.CreateTextEnd());  
                writer.End();
                
            }
            writer.Dispose();
            eb.Dispose();
            doc.Save(output_path + "element_builder.pdf", SDFDoc.SaveOptions.e_linearized);
            doc.Close();
