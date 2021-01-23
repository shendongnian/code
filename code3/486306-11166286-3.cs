     protected void ExportPDF(GridView gridViewReport)
        {
            int columnNumber = 0, rowNumber = 0;
            DataTable tbl = null;
    
            if (gridViewReport.AutoGenerateColumns)
            {
                tbl = gridViewReport.DataSource as DataTable; // Gets the DataSource of the GridView Control.
                columnNumber = tbl.Columns.Count;
                rowNumber = tbl.Rows.Count;
            }
            else
            {
                columnNumber = gridViewReport.Columns.Count;
                rowNumber = gridViewReport.Rows.Count;
            }
            // Creates a PDF document
            Document document = null;
            document = new Document(PageSize.A4, 0, 0, 15, 5);
            PdfPTable _table = new PdfPTable(GridView1.Columns.Count);
            _table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            BaseFont baseFont = BaseFont.CreateFont("c:\\\\windows\\\\fonts\\\\tahoma.ttf", BaseFont.IDENTITY_H, true); // Font which has Arabic characters
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
    
            // Sets the gridview column names as table headers.
            for (int i = 0; i < columnNumber; i++)
            {
                iTextSharp.text.pdf.PdfPCell ph = null;
    
                if (gridViewReport.AutoGenerateColumns)
                {
                    ph = new PdfPCell(new Phrase(10, tbl.Columns[i].ColumnName, font));
                }
                else
                {
                    ph = new PdfPCell(new Phrase(10, gridViewReport.Columns[i].HeaderText, font));
                }
                if (ph != null && gridViewReport.Columns[i].HeaderText != "")
                {
                    if (Regex.IsMatch(gridViewReport.Columns[i].HeaderText, "^[a-zA-Z0-9 ]*$")) // Check if Header Text is English
                    {
                        ph.RunDirection = PdfWriter.RUN_DIRECTION_LTR; // Left to Right
                        BaseColor color = new BaseColor(Color.Red);
                        ph.BackgroundColor = color;
                        _table.AddCell(ph);
                    }
                    else
                    {
                        ph.RunDirection = PdfWriter.RUN_DIRECTION_RTL; //Right to Left
                        BaseColor color = new BaseColor(Color.Red);
                        ph.BackgroundColor = color;
                        _table.AddCell(ph);
                    }
                }
                else
                {
                    ph.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    _table.AddCell(ph);
                }
            }
            // Get the gridview rows and adds them to the _table
            for (int rowIteration = 0; rowIteration < rowNumber; rowIteration++)
            {
                for (int columnIteration = 0; columnIteration < columnNumber; columnIteration++)
                {
                    if (gridViewReport.AutoGenerateColumns) //Check if AutoGenrated Colunms
                    {
                        string s = gridViewReport.Rows[rowIteration].Cells[columnIteration].Text.Trim();
                        PdfPCell ph = new PdfPCell(new Phrase(10, s, font));
                        _table.AddCell(ph);
                    }
                    else
                    {
                        if (gridViewReport.Columns[columnIteration] is TemplateField) // Check if Item Template
                        {
                            PdfPCell ph = null;
                            Label lc = gridViewReport.Rows[rowIteration].Cells[columnIteration].Controls[1] as Label; // Label
                            Button btn = gridViewReport.Rows[rowIteration].Cells[columnIteration].Controls[1] as Button;// Button
                            HyperLink hyperLink = gridViewReport.Rows[rowIteration].Cells[columnIteration].Controls[1] as HyperLink; // HyperLink
    
                            if (lc != null)
                            {
    
                                string s = lc.Text.Trim();
                                ph = new PdfPCell(new Phrase(10, s, font));
                                if (Regex.IsMatch(s, "^[a-zA-Z0-9 ]*$")) //Check if cell string is English
                                {   ph.RunDirection = PdfWriter.RUN_DIRECTION_LTR; // Left to Right
                                    _table.AddCell(ph); 
                                }
                                else
                                {
                                    ph.RunDirection = PdfWriter.RUN_DIRECTION_RTL; // Right to Left
                                    _table.AddCell(ph);
                                }
                              
                            }
                            else if (btn != null)
                            {
                                ph = new PdfPCell(new Phrase(10, btn.Text, font));
                                ph.Phrase.Clear(); // Clear the Cell Phrase
                                ph.Border = iTextSharp.text.Rectangle.NO_BORDER;
    
                                _table.AddCell(ph);
                            }
                            else if (hyperLink != null)
                            {
                                ph = new PdfPCell(new Phrase(10, hyperLink.Text, font));
                                ph.Phrase.Clear(); //Clear the Cell Phrase
                                ph.Border = iTextSharp.text.Rectangle.NO_BORDER; 
                                _table.AddCell(ph);
                            }
                            else
                            {
                                _table.AddCell("--");
                            }
                        }
                        else
                        {
                            string s = gridViewReport.Rows[rowIteration].Cells[columnIteration].Text.Trim();
                            PdfPCell ph = new PdfPCell(new Phrase(10, s, font));
                            _table.AddCell(ph);
                        }
                    }
                }
                _table.CompleteRow();
            }
            PdfWriter.GetInstance(document, Response.OutputStream);
            // Opens the document.
            document.Open();
            // Adds the _table to the document.
            document.Add(_table);
            // Closes the document.
            document.Close();
            Page.Response.ContentType = "application/pdf";
            Page.Response.AddHeader("content-disposition", "attachment;filename=MyGrid.pdf");
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Page.Response.Write(document);
            Page.Response.End();
    
        }
