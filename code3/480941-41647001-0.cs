    Dim wrd As New Microsoft.Office.Interop.Word.Application
    Dim intRefCount As Integer
    Do 
      intRefCount = System.Runtime.InteropServices.Marshal.ReleaseComObject(wrd)
    Loop While intRefCount > 0
    wrd = Nothing
