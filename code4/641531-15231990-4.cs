    Option Strict On
    Public Class Form1
      Const RowCount As Integer = 6
      Const ColumnCount As Integer = 8
      Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        For i = 0 To RowCount - 1
          For j = 0 To ColumnCount - 1
            Dim lbl As New Label
            lbl.Size = New Size(20, 20)
            lbl.Location = New Point(i * 20, j * 20)
            lbl.BackColor = If((i + j) Mod 2 = 0, Color.Black, Color.White)
            AddHandler lbl.Click, AddressOf lbl_Click
            Panel1.Controls.Add(lbl)
          Next
        Next
        MessageBox.Show(CountCellsOfColor(Color.Black))
      End Sub
      Private Function CountCellsOfColor(color As Color) As Integer
        Dim count As Integer = 0
        For Each lbl In Panel1.Controls.OfType(Of Label)()
          If lbl.BackColor = color Then count += 1
        Next
        Return count
      End Function
      Private Sub lbl_Click(sender As Object, e As System.EventArgs)
        Dim lbl As Label = CType(sender, Label)
        Dim color As Color = lbl.BackColor
        If color = Drawing.Color.Black Then
          color = Drawing.Color.White
        Else
          color = Drawing.Color.Black
        End If
        lbl.BackColor = color
      End Sub
    End Class
