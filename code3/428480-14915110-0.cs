    Private Sub MyDGV_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles MyDataGridView.RowPostPaint
    
        ' Automatically maintains a Row Header Index Number like the Excel row number, independent of sort order
    
        Dim grid As DataGridView = CType(sender, DataGridView)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()
        Dim RowFont As New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, _
                                            System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    
        Dim centerFormat = New StringFormat()
        centerFormat.Alignment = StringAlignment.Far
        centerFormat.LineAlignment = StringAlignment.Near
    
        Dim headerBounds As Rectangle = New Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)
        e.Graphics.DrawString(rowIdx, RowFont, SystemBrushes.ControlText, headerBounds, centerFormat)
    
        Exit Sub
    End Sub
