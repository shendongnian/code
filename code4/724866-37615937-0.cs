    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            MaskedTextBox1.Mask = "00:00"
            MaskedTextBox1.ValidatingType = GetType(DateTime)
            Me.validationToolTip.IsBalloon = True
    End Sub
    Private Sub MaskedTextBox1_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) _
            Handles MaskedTextBox1.TypeValidationCompleted
        If Not e.IsValidInput Then
            Me.validationToolTip.ToolTipTitle = "Invalid Time"
            Me.validationToolTip.Show("The time you supplied must be a valid time in the format HH:mm", sender, 0, -20, 5000)
        End If
    End Sub
