    Private Sub VoucherEmail_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Textbox.Validating
        If Not ValidateEmail(sender.Text) Then
            sender.backcolour = Validation.ErrorBackgrounColor
            e.Cancel = True
        End If
    End Sub
