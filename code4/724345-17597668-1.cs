        Dim fields() = {"field1", "field2", "field3", "field4", "field5"}
        'add tablix header row
        Dim tRowHeader = New RdlObjectModel.TablixRow With {.Height = New RdlObjectModel.ReportSize(0.2)}
        For i As Integer = 0 To fields.Length - 1
            Dim tCell = New RdlObjectModel.TablixCell
            Dim tCellContents = New RdlObjectModel.CellContents
            Dim tTextBox As New RdlObjectModel.Textbox
            tTextBox.Name = tablixRFoo.Name & "Header" & "txt" & fields(i).ToString.Replace(" ", "")
            tTextBox.DefaultName = tTextBox.Name
            tTextBox.Paragraphs(0).TextRuns(0).Value = fields(i).ToString
            tTextBox.Paragraphs(0).TextRuns(0).Style.FontSize = New RdlObjectModel.ReportSize("8pt")
            tTextBox.Paragraphs(0).TextRuns(0).Style.TextAlign = RdlObjectModel.TextAlignments.Left
            tTextBox.ZIndex = i
            tCellContents.ReportItem = tTextBox
            tCell.CellContents = tCellContents
            tRowHeader.TablixCells.Add(tCell)
            tColHeirarcy.TablixMembers.Add(New RdlObjectModel.TablixMember)
        Next
        tablixRFoo.TablixBody.TablixRows.Add(tRowHeader)
        'add tablix data rows
        Dim tRow = New RdlObjectModel.TablixRow With {.Height = New RdlObjectModel.ReportSize(0.2)}
        For i As Integer = 0 To fields.Length - 1
            Dim tCell = New RdlObjectModel.TablixCell
            Dim tCellContents = New RdlObjectModel.CellContents
            Dim tTextBox As New RdlObjectModel.Textbox
            tTextBox.Name = tablixRFoo.Name & "txt" & fields(i).ToString.Replace(" ", "")
            tTextBox.DefaultName = tTextBox.Name
            tTextBox.Paragraphs(0).TextRuns(0).Value = "=Fields!" & fields(i).ToString & ".Value"
            tTextBox.Paragraphs(0).TextRuns(0).Style.FontSize = New RdlObjectModel.ReportSize("8pt")
            tTextBox.Paragraphs(0).TextRuns(0).Style.TextAlign = RdlObjectModel.TextAlignments.Left
            tTextBox.ZIndex = i
            tCellContents.ReportItem = tTextBox
            tCell.CellContents = tCellContents
            tRow.TablixCells.Add(tCell)
        Next
        tablixRFoo.TablixBody.TablixRows.Add(tRow)
        Dim rMem = New RdlObjectModel.TablixMember With {.KeepTogether = True}
        Dim rMem2 = New RdlObjectModel.TablixMember With {.Group = New RdlObjectModel.Group With {.Name = "Details"}}
        tRowHeirarcy.TablixMembers.Add(rMem)
        tRowHeirarcy.TablixMembers.Add(rMem2)
        tablixRFoo.Style = New RdlObjectModel.Style With {.Border = New RdlObjectModel.Border}
        'add tablix to report
        tablixRFoo.TablixColumnHierarchy = tColHeirarcy
        tablixRFoo.TablixRowHierarchy = tRowHeirarcy
        rdlRpt.Body.ReportItems.Add(tablixRFoo)
