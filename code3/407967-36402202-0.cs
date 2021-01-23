    Public Class HybridDataGridView
    Inherits DataGridView
    WithEvents NewDataGridViewTextBox As New TextBox
    Private NoFocus As Integer = 0
    
     Private Sub HybridDataGridView_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        NoFocus = 1
     End Sub
     Private Sub HybridDataGridView_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        NoFocus = 0
      End Sub
     Private Sub HybridDataGridView_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Me.CellPainting
        If Me.CurrentCell Is Nothing Then
            Exit Sub
        End If
        Dim Kalem As Pen
        If e.ColumnIndex = Me.CurrentCell.ColumnIndex And e.RowIndex = Me.CurrentCell.RowIndex Then
            If NoFocus = 0 Then
               Kalem = New Pen(Color.Black, 1)
               e.PaintBackground(e.ClipBounds, True)
               e.PaintContent(e.ClipBounds)
             End if
          End if
      End sub
    End Class
