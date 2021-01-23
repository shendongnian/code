                    else
                    {
                        int newPageNumber = 3;
                        int currentPage = 2;
                        int lastLinePrinted = 0;
                        int maxLine = 9;
                        bool lastPage = false;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                            {
                                datatable.DefaultCell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                                Phrase phrase = new Phrase(ds.Tables[0].Rows[i][j].ToString(), FontFactory.GetFont("Verdana", 9));
                                datatable.AddCell(phrase);
                            }
                            // must decrement the ds.Tables[0].Rows.Count here, 
                            // otherwise it'll never enter the code below, we'll
                            // increment it back when we reach the last page
                            if ((i > 0 && i % 9 == 0) || i == ds.Tables[0].Rows.Count - 1)
                            {
                                PdfContentByte content = pdfStamper.GetUnderContent(currentPage);
                                datatable.WriteSelectedRows(lastLinePrinted, maxLine, 70.0f, 495.0f, content);
                                if (!lastPage)
                                {
                                    pdfStamper.InsertPage(newPage, pdfReader.GetPageSize(2));
                                    newPage++;
                                    currentPage++;
                                    lastLinePrinted = maxLine;
                                    maxLine += 9;
                                }
                                if (maxLine > ds.Tables[0].Rows.Count)
                                {
                                    maxLine = ds.Tables[0].Rows.Count+1;
                                    lastPage = true;
                                }
                            }
                        }
                    }
