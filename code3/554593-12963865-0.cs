    Dim xl As excel.Application
    Dim StartLine As Long, StartColumn As Long, EndLine As Long, EndColumn As Long
    Set xl = GetObject(, "Excel.Application")
    xl.VBE.ActiveCodePane.GetSelection StartLine, StartColumn, EndLine, EndColumn
    Debug.Print StartLine, StartColumn, EndLine, EndColumn
