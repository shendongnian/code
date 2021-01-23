    Private Sub ForceStopAfterFirstBind(sender As Object, e As RepeaterItemEventArgs)
        If e.Item.ItemIndex > 3 Then
            e.Item.Controls.Clear()
        End If
    End Sub
