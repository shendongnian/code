        Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim c1 As Control = Me.tlp.GetControlFromPosition(0, 0)
        Dim c2 As Control = Me.tlp.GetControlFromPosition(0, 1)
        If c1 IsNot Nothing And c2 IsNot Nothing Then
            tlp.Controls.SetChildIndex(c1, 1)
            tlp.Controls.SetChildIndex(c2, 0)
        End If
    End Sub
