    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      For i As Integer = 0 To DataGridView1.Rows.Count - 1
        'Dim CheckBox As DataGridViewCheckBoxCell = DirectCast(DataGridView1.Rows(i).Cells(0), DataGridViewCheckBoxCell)
        'If Not CheckBox.Value = Not CheckBox.Value Then
        '  MsgBox("True")
        'End If
        Dim obj As Object = DataGridView1.Rows(i).Cells(0)
        If (Not obj Is Nothing) Then
          Dim checkBox1 As DataGridViewCheckBoxCell = DirectCast(obj, DataGridViewCheckBoxCell)
          Dim objValue As Object = checkBox1.Value
          If (Not objValue Is Nothing) Then
            Dim checked As Boolean = DirectCast(objValue, Boolean)
            If (checked) Then
              MsgBox("True")
            End If
          End If
        End If
      Next
    End Sub
