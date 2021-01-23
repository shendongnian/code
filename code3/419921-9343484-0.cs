        Imports System.Runtime.CompilerServices
    Imports Excel = Microsoft.Office.Interop.Excel
    Public Module ExcelMod
    
        <Extension()> _
        Public Function ToExcel(ByVal grd As DataGridView, ByVal path As String, Optional ByRef exp As Exception = Nothing) As Boolean
            Dim res As Boolean = False
            exp = Nothing
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Try
    
                Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
    
                Dim misValue As Object = System.Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer
    
                xlApp = New Excel.ApplicationClass
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
    
                xlWorkBook = xlApp.Workbooks.Add(misValue)
                xlWorkSheet = xlWorkBook.Sheets("sheet1")
    
                Dim lastCol As Integer = 0
                Dim lastRow As Integer = 0
                For j = 0 To grd.ColumnCount - 1
                    If grd.Columns(j).Visible Then
                        xlWorkSheet.Columns(lastCol + 1).ColumnWidth = CInt(grd.Columns(j).Width / 10)
                        xlWorkSheet.Cells(1, lastCol + 1) = grd.Columns(j).HeaderText
                        lastCol += 1
                    End If
                Next
    
                lastRow = 0
                For i = 0 To grd.RowCount - 1
                    lastCol = 0
                    For j = 0 To grd.ColumnCount - 1
                        If grd.Columns(j).Visible AndAlso grd.Rows(i).Visible Then
    
                            If grd(j, i).FormattedValue <> Nothing Then _
                                xlWorkSheet.Cells(lastRow + 2, lastCol + 1) = grd(j, i).FormattedValue.ToString()
    
                            lastCol += 1
    
                        End If
                    Next
                    If grd.Rows(i).Visible Then lastRow += 1
                Next
    
    
                xlWorkSheet.SaveAs(path)
                xlWorkBook.Close()
                xlApp.Quit()
    
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
                res = True
    
            Catch ex As Exception
                exp = ex
            Finally
                If xlApp IsNot Nothing Then releaseObject(xlApp)
                If xlWorkBook IsNot Nothing Then releaseObject(xlWorkBook)
                If xlWorkSheet IsNot Nothing Then releaseObject(xlWorkSheet)
            End Try
    
            Return res
        End Function
    
        Private Sub releaseObject(ByVal obj As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            Catch ex As Exception
                obj = Nothing
            Finally
                GC.Collect()
            End Try
        End Sub
    
    End Module
