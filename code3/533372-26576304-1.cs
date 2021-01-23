        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ValidateChildren() Then
            MessageBox.Show("Validation succeeded!")
        Else
            MessageBox.Show("Validation failed.")
        End If
    End Sub
