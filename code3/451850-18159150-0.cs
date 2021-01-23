    public partial class Footer : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
           Paragraph footer= new Paragraph("THANK YOU", FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL));
           footer.Alignment = Element.ALIGN_RIGHT;
           PdfPTable footerTbl = new PdfPTable(1);
           footerTbl.TotalWidth = 300;
           footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
        
           PdfPCell cell = new PdfPCell(footer);
           cell.Border = 0;
           cell.PaddingLeft = 10;
        
           footerTbl.AddCell(cell);
           footerTbl.WriteSelectedRows(0, -1, 415, 30, writer.DirectContent);
        }
    }
