    private static PdfPCell GetCellForBorderedTable(Phrase phrase, int align, BaseColor color)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        cell.BackgroundColor = color;
        cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
        return cell;
    }
    
    private static PdfPCell GetCellForBorderlessTable(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.HorizontalAlignment = align;            
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        cell.BorderWidth = PdfPCell.NO_BORDER;
        cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
        return cell;
    }
