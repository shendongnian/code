			Font qFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 10);
			List<float> widths = new List<float>();
			for(int i = 0; i < qs.Selected.Items.Count; i++) {
				widths.Add((pageRectangle.Width - 250)/ qs.Selected.Items.Count);
			}
			PdfPTable table = new PdfPTable(qs.Selected.Items.Count);
			table.HorizontalAlignment = Element.ALIGN_CENTER;
			table.SetTotalWidth(widths.ToArray());
			foreach(System.Web.UI.WebControls.ListItem answer in qs.Selected.Items) {
				cell = new PdfPCell();
				cell.Border = Rectangle.NO_BORDER;
    /******************** RELEVANT CODE STARTS HERE ***************************/
                Paragraph p = new Paragraph(answer.Text, aFont);
                p.Alignment = Element.ALIGN_CENTER;
				cell.AddElement(p);
				table.AddCell(cell);
    /******************** RELEVANT CODE  ENDS  HERE ***************************/
			}
