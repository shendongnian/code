    Public Sub AnimateProgBar(ByVal milliSeconds As Integer)
        If Not Timer1.Enabled Then
            ProgressBar1.Value = 0
            Timer1.Interval = CInt(milliSeconds / 100)
            Timer1.Enabled = True
        End If
    End Sub
    Private Sub AnimatingProgBar(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value += 1
            ProgressBar1.Refresh()
        Else
            Timer1.Enabled = False
        End If
    End Sub
