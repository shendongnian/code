    Font timesRoman9Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, BaseColor.BLACK);
    Font timesRoman9BoldFont = FontFactory.GetFont(FontFactory.TIMES_BOLD, 9, BaseColor.BLACK);
    
    Phrase phrasesec1Heading = new Phrase("Duckbills Unlimited", timesRoman9BoldFont);
    PdfPCell cellSec1Heading = GetCellForBorderedTable(phrasesec1Heading, Element.ALIGN_LEFT, BaseColor.YELLOW);
    tblHeadings.AddCell(cellSec1Heading);
    
    Phrase phraseReqDate = new Phrase("Poison Toe Toxicity Level (Metric Richter Scale, adjusted for follicle hue)", timesRoman9Font);
    PdfPCell cellReqDate = GetCellForBorderlessTable(phraseReqDate, Element.ALIGN_LEFT);
    tblFirstRow.AddCell(cellReqDate);
    tblFirstRow.AddCell(cellReqDateTextBox);
