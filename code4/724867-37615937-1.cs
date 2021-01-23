    Private Sub MaskedTextBox1_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) _
            Handles MaskedTextBox1.Validating
        Dim senderAsMask = DirectCast(sender, MaskedTextBox)
        Dim value = senderAsMask.Text
        Dim parsable = Date.TryParse(value, New Date)
        If Not parsable Then
            e.Cancel = True
            Me.validationToolTip.ToolTipTitle = "Invalid Time"
            Me.validationToolTip.Show("The time you supplied must be a valid time in the format HH:mm", sender, 0, -20, 5000)
        End If
    End Sub
