    public static PdfPCell MakeHeader(string text, iTextSharp.text.Font Htitle) {
        PdfPCell HeadCell = new PdfPCell(new Paragraph(text, Htitle));
        HeadCell.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        return HeadCell;
    }
    PdfPCell HeadCell0 = MakeHeader("FullName", Htitle);
