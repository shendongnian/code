    Private Sub MyDGV_RowPostPaint(sender As Object, _
        e As DataGridViewRowPostPaintEventArgs) Handles MyDataGridView.RowPostPaint
    
        ' Automatically maintains a Row Header Index Number 
        '   like the Excel row number, independent of sort order
    
        Dim grid As DataGridView = CType(sender, DataGridView)
        Dim rowIdx As String = (e.RowIndex + 1).ToString()
        Dim rowFont As New System.Drawing.Font("Tahoma", 8.0!, _
            System.Drawing.FontStyle.Bold, _
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    
        Dim centerFormat = New StringFormat()
        centerFormat.Alignment = StringAlignment.Far
        centerFormat.LineAlignment = StringAlignment.Near
    
        Dim headerBounds As Rectangle = New Rectangle(_
            e.RowBounds.Left, e.RowBounds.Top, _
            grid.RowHeadersWidth, e.RowBounds.Height)
        e.Graphics.DrawString(rowIdx, rowFont, SystemBrushes.ControlText, _
            headerBounds, centerFormat)
    End Sub
