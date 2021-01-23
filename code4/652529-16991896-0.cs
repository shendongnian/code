    Function IsVBEActive(wb as Workbook) As Boolean
    
    Dim vbProj
    
    Set vbProj = wb.vbProject
    IsVBEActive <> vbProj.VBE.ActiveWindow Is Nothing
    End Sub
