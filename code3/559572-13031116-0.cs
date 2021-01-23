    using System.Diagnostics;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
     
    namespace RowsCountSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var pdfDoc = new Document(PageSize.A4))
                {
                    var pdfWriter = PdfWriter.GetInstance(pdfDoc, new FileStream("Test.pdf", FileMode.Create));
                    pdfDoc.Open();
     
                    var table1 = new PdfPTable(3);
                    table1.HeaderRows = 2;
                    table1.FooterRows = 1;
     
                    //header row 
                    var headerCell = new PdfPCell(new Phrase("header"));
                    headerCell.Colspan = 3;
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table1.AddCell(headerCell);
     
                    //footer row 
                    var footerCell = new PdfPCell(new Phrase("footer"));
                    footerCell.Colspan = 3;
                    footerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table1.AddCell(footerCell);
     
                    //adding some rows 
                    for (int i = 0; i < 70; i++)
                    {
                        //adds a new row
                        table1.AddCell(new Phrase("Cell[0], Row[" + i + "]"));
                        table1.AddCell(new Phrase("Cell[1], Row[" + i + "]"));
                        table1.AddCell(new Phrase("Cell[2], Row[" + i + "]"));
     
                        //sets the number of rows per page
                        if (i > 0 && table1.Rows.Count % 7 == 0)
                        {
                            pdfDoc.Add(table1);
                            table1.DeleteBodyRows();
                            pdfDoc.NewPage();
                        }
                    }
     
                    pdfDoc.Add(table1);
                }
     
                //open the final file with adobe reader for instance. 
                Process.Start("Test.pdf");
            }
        }
    }
