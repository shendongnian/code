    public class MyPageEventHandler : iTextSharp.text.pdf.PdfPageEventHelper {
        public override void OnEndPage(PdfWriter writer, Document document) {
            //Create a simple ColumnText object
            var CT = new ColumnText(writer.DirectContent);
            //Bind it to the top of the document but take up the entire page width
            CT.SetSimpleColumn(0, document.PageSize.Height - 20, document.PageSize.Width, document.PageSize.Height);
            //Add some text
            CT.AddText(new Phrase("This is a test"));
            //Draw our ColumnText object
            CT.Go();
        }
    }
