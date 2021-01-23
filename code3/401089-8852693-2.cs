            using (FileStream fs = new FileStream(workingFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
                using (Document doc = new Document(PageSize.LETTER)) {
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)) {
                        doc.Open();
                        doc.Add(new Paragraph("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna."));
                        doc.Add(new Paragraph("This"));
                        doc.Add(new Paragraph("Is"));
                        doc.Add(new Paragraph("A"));
                        doc.Add(new Paragraph("Test"));
                        doc.Close();
                    }
                }
            }
