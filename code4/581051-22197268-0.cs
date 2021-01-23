            try
            {
                
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "All Files | *.*  ";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    string path = saveFileDialog.FileName;
                    Document pdfdoc = new Document(PageSize.A4); // Setting the page size for the PDF
                    PdfWriter writer = PdfWriter.GetInstance(pdfdoc, new FileStream(path + ".pdf", FileMode.Create)); //Using the PDF Writer class to generate the PDF
                    writer.PageEvent = new PDFFooter();
                     // Opening the PDF to write the data from the textbox
                    PdfPTable table = new PdfPTable(jdgvChild.Columns.Count);
                    //table.TotalWidth = GridView.Width;
                    
                    float[] widths = new float[] { jdgvChild.Columns[0].Width, jdgvChild.Columns[1].Width, jdgvChild.Columns[2].Width, 
                                           jdgvChild.Columns[3].Width, jdgvChild.Columns[4].Width, jdgvChild.Columns[5].Width,
                                           jdgvChild.Columns[6].Width, jdgvChild.Columns[7].Width};
                    table.SetWidths(widths);
                    table.HorizontalAlignment = 1; // 0 - left, 1 - center, 2 - right;
                    table.SpacingBefore = 2.0F;
                    PdfPCell cell = null;
                    pdfdoc.Open();
                    //doc.Open();
                 //   Phrase p = new Phrase(new Chunk(heading, titleFont));
                   // doc.Add(p);
                    foreach (GridViewDataColumn c in jdgvChild.Columns)
                    {
                        cell = new PdfPCell(new Phrase(new Chunk(c.HeaderText)));
                        
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cell);
                    }
                    if (jdgvChild.Rows.Count > 0)
                    {
                       for (int i = 0; i < jdgvChild.Rows.Count; i++)
                        {
                     
                        PdfPCell[] objcell = new PdfPCell[jdgvChild.Columns.Count];
 
                            for (int j = 0; j < jdgvChild.Columns.Count-1; j++)
                            {
                                cell = new PdfPCell(new Phrase(jdgvChild.Rows[i].Cells[j].Value.ToString()));
                                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                               // table.AddCell(cell);
                                //lstCells.Add(cell);
                                objcell[j] = cell;
                            }
                            PdfPRow newrow = new PdfPRow(objcell);
                            table.Rows.Add(newrow);
                        }
                    }
                   
                    
                    pdfdoc.Add(table);
                    
                    MessageBox.Show("Pdf Generation Successfully.");
                  pdfdoc.Close();
                }
            }
             catch (Exception ex)
            {
                MessageBox.Show("Error in pdf Generation.");
            }
        }
