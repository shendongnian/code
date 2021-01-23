    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tlp.RowStyles.Clear()
        For i As Integer = 0 To 4
            Dim txt As New TextBox
            txt.Text = i
            txt.Name = "txt" & i
            tlp.Controls.Add(txt) 'this works
            'tlp.Controls.Add(txt, 0, i) 'this will not work when button is clicked
        Next
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim c1 As Control = Me.tlp.GetControlFromPosition(0, 0)
        Dim c2 As Control = Me.tlp.GetControlFromPosition(0, 1)
        If c1 IsNot Nothing And c2 IsNot Nothing Then
            tlp.Controls.SetChildIndex(c1, 1)
            tlp.Controls.SetChildIndex(c2, 0)
        End If
    End Sub
