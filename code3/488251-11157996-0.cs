    Protected Sub ExportToPDF(gvReport As GridView, LandScape As Boolean)
	Dim noOfColumns As Integer = 0, noOfRows As Integer = 0
	Dim tbl As DataTable = Nothing
	If gvReport.AutoGenerateColumns Then
		tbl = TryCast(gvReport.DataSource, DataTable)
		' Gets the DataSource of the GridView Control.
		noOfColumns = tbl.Columns.Count
		noOfRows = tbl.Rows.Count
	Else
		noOfColumns = gvReport.Columns.Count
		noOfRows = gvReport.Rows.Count
	End If
	Dim HeaderTextSize As Single = 8
	Dim ReportNameSize As Single = 10
	Dim ReportTextSize As Single = 8
	Dim ApplicationNameSize As Single = 7
	' Creates a PDF document
	Dim document As Document = Nothing
	If LandScape = True Then
		' Sets the document to A4 size and rotates it so that the     orientation of the page is Landscape.
		document = New Document(PageSize.A4.Rotate(), 0, 0, 15, 5)
	Else
		document = New Document(PageSize.A4, 0, 0, 15, 5)
	End If
	' Creates a PdfPTable with column count of the table equal to no of columns of the gridview or gridview datasource.
	Dim mainTable As New iTextSharp.text.pdf.PdfPTable(noOfColumns)
	' Sets the first 4 rows of the table as the header rows which will be repeated in all the pages.
	mainTable.HeaderRows = 4
	' Creates a PdfPTable with 2 columns to hold the header in the exported PDF.
	Dim headerTable As New iTextSharp.text.pdf.PdfPTable(2)
	' Creates a phrase to hold the application name at the left hand side of the header.
	Dim phApplicationName As New Phrase("Sample Application", FontFactory.GetFont("Arial", ApplicationNameSize, iTextSharp.text.Font.NORMAL))
	' Creates a PdfPCell which accepts a phrase as a parameter.
	Dim clApplicationName As New PdfPCell(phApplicationName)
	' Sets the border of the cell to zero.
	clApplicationName.Border = PdfPCell.NO_BORDER
	' Sets the Horizontal Alignment of the PdfPCell to left.
	clApplicationName.HorizontalAlignment = Element.ALIGN_LEFT
	' Creates a phrase to show the current date at the right hand side of the header.
	Dim phDate As New Phrase(DateTime.Now.[Date].ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", ApplicationNameSize, iTextSharp.text.Font.NORMAL))
	' Creates a PdfPCell which accepts the date phrase as a parameter.
	Dim clDate As New PdfPCell(phDate)
	' Sets the Horizontal Alignment of the PdfPCell to right.
	clDate.HorizontalAlignment = Element.ALIGN_RIGHT
	' Sets the border of the cell to zero.
	clDate.Border = PdfPCell.NO_BORDER
	' Adds the cell which holds the application name to the headerTable.
	headerTable.AddCell(clApplicationName)
	' Adds the cell which holds the date to the headerTable.
	headerTable.AddCell(clDate)
	' Sets the border of the headerTable to zero.
	headerTable.DefaultCell.Border = PdfPCell.NO_BORDER
	' Creates a PdfPCell that accepts the headerTable as a parameter and then adds that cell to the main PdfPTable.
	Dim cellHeader As New PdfPCell(headerTable)
	cellHeader.Border = PdfPCell.NO_BORDER
	' Sets the column span of the header cell to noOfColumns.
	cellHeader.Colspan = noOfColumns
	' Adds the above header cell to the table.
	mainTable.AddCell(cellHeader)
	' Creates a phrase which holds the file name.
	Dim phHeader As New Phrase("Sample Export", FontFactory.GetFont("Arial", ReportNameSize, iTextSharp.text.Font.BOLD))
	Dim clHeader As New PdfPCell(phHeader)
	clHeader.Colspan = noOfColumns
	clHeader.Border = PdfPCell.NO_BORDER
	clHeader.HorizontalAlignment = Element.ALIGN_CENTER
	mainTable.AddCell(clHeader)
	' Creates a phrase for a new line.
	Dim phSpace As New Phrase(vbLf)
	Dim clSpace As New PdfPCell(phSpace)
	clSpace.Border = PdfPCell.NO_BORDER
	clSpace.Colspan = noOfColumns
	mainTable.AddCell(clSpace)
	' Sets the gridview column names as table headers.
	For i As Integer = 0 To noOfColumns - 1
		Dim ph As Phrase = Nothing
		If gvReport.AutoGenerateColumns Then
			ph = New Phrase(tbl.Columns(i).ColumnName, FontFactory.GetFont("Arial", HeaderTextSize, iTextSharp.text.Font.BOLD))
		Else
			ph = New Phrase(gvReport.Columns(i).HeaderText, FontFactory.GetFont("Arial", HeaderTextSize, iTextSharp.text.Font.BOLD))
		End If
		mainTable.AddCell(ph)
	Next
	' Reads the gridview rows and adds them to the mainTable
	For rowNo As Integer = 0 To noOfRows - 1
		For columnNo As Integer = 0 To noOfColumns - 1
			If gvReport.AutoGenerateColumns Then
				Dim s As String = gvReport.Rows(rowNo).Cells(columnNo).Text.Trim()
				Dim ph As New Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL))
				mainTable.AddCell(ph)
			Else
				If TypeOf gvReport.Columns(columnNo) Is TemplateField Then
					Dim lc As DataBoundLiteralControl = TryCast(gvReport.Rows(rowNo).Cells(columnNo).Controls(0), DataBoundLiteralControl)
					Dim s As String = lc.Text.Trim()
					Dim ph As New Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL))
					mainTable.AddCell(ph)
				Else
					Dim s As String = gvReport.Rows(rowNo).Cells(columnNo).Text.Trim()
					Dim ph As New Phrase(s, FontFactory.GetFont("Arial", ReportTextSize, iTextSharp.text.Font.NORMAL))
					mainTable.AddCell(ph)
				End If
			End If
		Next
		' Tells the mainTable to complete the row even if any cell is left incomplete.
		mainTable.CompleteRow()
	Next
	' Gets the instance of the document created and writes it to the output stream of the Response object.
	PdfWriter.GetInstance(document, Response.OutputStream)
	' Creates a footer for the PDF document.
	Dim pdfFooter As New HeaderFooter(New Phrase(), True)
	pdfFooter.Alignment = Element.ALIGN_CENTER
	pdfFooter.Border = iTextSharp.text.Rectangle.NO_BORDER
	' Sets the document footer to pdfFooter.
	document.Footer = pdfFooter
	' Opens the document.
	document.Open()
	' Adds the mainTable to the document.
	document.Add(mainTable)
	' Closes the document.
	document.Close()
	Response.ContentType = "application/pdf"
	Response.AddHeader("content-disposition", "attachment; filename= SampleExport.pdf")
	Response.[End]()
