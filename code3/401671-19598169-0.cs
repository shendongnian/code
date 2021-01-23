    
    Sub AutoFitMergedCellRowHeight()
    Dim CurrentRowHeight As Single, MergedCellRgWidth As Single
    Dim CurrCell As Range
    Dim ActiveCellWidth As Single, PossNewRowHeight As Single
    Dim StartCell As Range, c As Range, MergeRng As Range, Cell As Range
    Dim a() As String, isect As Range, i
    
        
    'Take a note of current active cell
    Set StartCell = ActiveCell
    
    'Create an array of merged cell addresses that have wrapped text
    For Each c In ActiveSheet.UsedRange
    If c.MergeCells Then
        With c.MergeArea
        If .Rows.Count = 1 And .WrapText = True Then
            If MergeRng Is Nothing Then
                Set MergeRng = c.MergeArea
                ReDim a(0)
                a(0) = c.MergeArea.Address
            Else
            Set isect = Intersect(c, MergeRng)
                If isect Is Nothing Then
                    Set MergeRng = Union(MergeRng, c.MergeArea)
                    ReDim Preserve a(UBound(a) + 1)
                    a(UBound(a)) = c.MergeArea.Address
                End If
            End If
        End If
        End With
    End If
    Next c
    
    
    Application.ScreenUpdating = False
    
    'Loop thru merged cells
    For i = 0 To UBound(a)
    Range(a(i)).Select
          With ActiveCell.MergeArea
                If .Rows.Count = 1 And .WrapText = True Then
                    'Application.ScreenUpdating = False
                    CurrentRowHeight = .RowHeight
                    ActiveCellWidth = ActiveCell.ColumnWidth
                    For Each CurrCell In Selection
                        MergedCellRgWidth = CurrCell.ColumnWidth + MergedCellRgWidth
                    Next
                    .MergeCells = False
                    .Cells(1).ColumnWidth = MergedCellRgWidth
                    .EntireRow.AutoFit
                    PossNewRowHeight = .RowHeight
                    .Cells(1).ColumnWidth = ActiveCellWidth
                    .MergeCells = True
                    .RowHeight = IIf(CurrentRowHeight > PossNewRowHeight, _
                      CurrentRowHeight, PossNewRowHeight)
                End If
            End With
    MergedCellRgWidth = 0
    Next i
    
    StartCell.Select
    Application.ScreenUpdating = True
    
    'Clean up
    Set CurrCell = Nothing
    Set StartCell = Nothing
    Set c = Nothing
    Set MergeRng = Nothing
    Set Cell = Nothing
    
    End Sub
