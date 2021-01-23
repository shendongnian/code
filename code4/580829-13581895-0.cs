	PdfPCell cell;
	PdfPTable tableHeader;
	PdfPTable tmpTable;
	PdfPTable table = new PdfPTable(10) { WidthPercentage = 100, RunDirection = PdfWriter.RUN_DIRECTION_LTR, ExtendLastRow = false };
	// row 1 / cell 1 (merge)
	PdfPCell _c = new PdfPCell(new Phrase("SER. No")) { Rotation = -90, VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidth = 1 };
	_c.Rowspan = 2;
	table.AddCell(_c);
	// row 1 / cell 2
	_c = new PdfPCell(new Phrase("TYPE OF SHIPPING")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	table.AddCell(_c);
	// row 1 / cell 3
	_c = new PdfPCell(new Phrase("ORDER NO.")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	table.AddCell(_c);
	// row 1 / cell 4
	_c = new PdfPCell(new Phrase("QTY.")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	table.AddCell(_c);
	// row 1 / cell 5
	_c = new PdfPCell(new Phrase("DISCHARGE PPORT")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	table.AddCell(_c);
	// row 1 / cell 6 (merge)
	_c = new PdfPCell(new Phrase("DESCRIPTION OF GOODS")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	_c.Rowspan = 2;
	table.AddCell(_c);
	// row 1 / cell 7
	_c = new PdfPCell(new Phrase("LINE DOC. RECI. DATE")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	table.AddCell(_c);
	// row 1 / cell 8 (merge)
	_c = new PdfPCell(new Phrase("OWNER DOC. RECI. DATE")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	_c.Rowspan = 2;
	table.AddCell(_c);
	// row 1 / cell 9 (merge)
	_c = new PdfPCell(new Phrase("CLEARANCE DATE")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	_c.Rowspan = 2;
	table.AddCell(_c);
	// row 1 / cell 10 (merge)
	_c = new PdfPCell(new Phrase("CUSTOM PERMIT NO.")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	_c.Rowspan = 2;
	table.AddCell(_c);
	// row 2 / cell 2
	_c = new PdfPCell(new Phrase("AWB / BL NO.")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	table.AddCell(_c);
	// row 2 / cell 3
	_c = new PdfPCell(new Phrase("COMPLEX NAME")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	table.AddCell(_c);
	// row 2 / cell 4
	_c = new PdfPCell(new Phrase("G.W Kgs.")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	table.AddCell(_c);
	// row 2 / cell 5
	_c = new PdfPCell(new Phrase("DESTINATON")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	table.AddCell(_c);
	// row 2 / cell 7
	_c = new PdfPCell(new Phrase("OWNER DOC. RECI. DATE")) { VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
	table.AddCell(_c);
	_doc.Add(table);
	///////////////////////////////////////////////////////////
	_doc.Close();
