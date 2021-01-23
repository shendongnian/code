    ''' <summary>
    ''' Allows you to reference a column by its numeric index rather than its alphabetic representation
    ''' </summary>
    ''' <param name="colNum">The index of the column to reference on in the worksheet.</param>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Columns(ByVal wks As ExcelWorksheet, ByVal colNum As Integer) As ExcelRange
        Dim ColName As String = ReturnColumnName(colNum)
        Return wks.Cells(ColName & ":" & ColName)
    End Function
    ''' <summary>
    ''' Allows you to reference a column by its numeric index rather than its alphabetic representation
    ''' </summary>
    ''' <param name="StartColNum">The start col num.</param>
    ''' <param name="EndColNum">The end col num.</param>
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Columns(ByVal wks As ExcelWorksheet, ByVal StartColNum As Integer, ByVal EndColNum As Integer) As ExcelRange
        Dim StartColName As String = ReturnColumnName(StartColNum)
        Dim EndColName As String = ReturnColumnName(EndColNum)
        Return wks.Cells(StartColName & ":" & EndColName)
    End Function
    Private Function ReturnColumnName(ByVal colNum As Integer) As String
        Dim d As Integer
        Dim m As Integer
        Dim Name As String
        d = colNum
        Name = ""
        Do While (d > 0)
            m = (d - 1) Mod 26
            Name = Chr(65 + m) + Name
            d = Int((d - m) / 26)
        Loop
        Return Name
    End Function
