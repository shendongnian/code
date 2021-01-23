    Private PivotDoubleClicked As Boolean
    Private Sub Workbook_SheetBeforeDoubleClick(ByVal Sh As Object, ByVal Target As Range, Cancel As Boolean)
    Dim pt As Excel.PivotTable
    On Error Resume Next
    Set pt = Target.PivotTable
    If Err.Number = 0 Then
        PivotDoubleClicked = True
    End If
    End Sub
    
    Private Sub Workbook_NewSheet(ByVal Sh As Object)
    If PivotDoubleClicked Then
        MsgBox "new sheet from pivot double-click"
        PivotDoubleClicked = False
    End If
    End Sub
