            doc.Open();
            doc.Add(new Paragraph(new Chunk("Header for Searches" + Chunk.NEWLINE + Chunk.NEWLINE, fb)));
            PdfPTable tableSearches = new PdfPTable(3);
            PdfPCell cellSearches = new PdfPCell();
            cellSearches.BackgroundColor = BaseColor.WHITE;
            cellSearches.Phrase = new Phrase("Facility ID");
            tableSearches.AddCell(cellSearches);
            cellSearches.Phrase = new Phrase("Facility");
            tableSearches.AddCell(cellSearches);
            cellSearches.Phrase = new Phrase("Phone Number");
            tableSearches.AddCell(cellSearches);
            //loop through the records in facilities collection and add row
            foreach (var m in facilityList)
            {
                cellSearches.BackgroundColor = BaseColor.LIGHT_GRAY;
                cellSearches.Phrase = new Phrase(m.Id.ToString());
                tableSearches.AddCell(cellSearches);
                cellSearches.Phrase = new Phrase(m.Facility);
                tableSearches.AddCell(cellSearches);
                cellSearches.Phrase = new Phrase(m.Phone);
                tableSearches.AddCell(cellSearches);
            }
            doc.Add(tableSearches);
            //Page 2? AM Searches
            doc.NewPage();
            doc.Add(new Paragraph(new Chunk("Header for AM Searches" + Chunk.NEWLINE + Chunk.NEWLINE, fb)));
            PdfPTable tableAM = new PdfPTable(3);
            PdfPCell cellAM = new PdfPCell();
            cellAM.BackgroundColor = BaseColor.WHITE;
            cellAM.Phrase = new Phrase("Facility ID");
            tableAM.AddCell(cellAM);
            cellAM.Phrase = new Phrase("Facility");
            tableAM.AddCell(cellAM);
            cellAM.Phrase = new Phrase("Phone Number");
            tableAM.AddCell(cellAM);
            //loop through the records and add row
            foreach (var m in facilityList)
            {
                cellAM.BackgroundColor = BaseColor.CYAN;
                cellAM.Phrase = new Phrase(m.Id.ToString());
                tableAM.AddCell(cellAM);
                cellAM.Phrase = new Phrase(m.Facility);
                tableAM.AddCell(cellAM);
                cellAM.Phrase = new Phrase(m.Phone);
                tableAM.AddCell(cellAM);
            }
            doc.Add(tableAM);
            doc.Close();
