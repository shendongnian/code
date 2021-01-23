    'declare the event
    Public Event ControlClick()
    'raise the event when the control is clicked
    Private Sub UserControl1_Click(sender As Object, e As System.EventArgs) Handles Me.Click
        RaiseEvent ControlClick()
    End Sub
