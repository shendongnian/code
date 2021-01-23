    WithEvents Tmr As New Timer With {.Interval = 100}
    Dim startTime As Date, AnimationTime%
    Sub AnimateProgress(ms%)
        If ms <= 0 Then Exit Sub
        ProgressBar1.Value = 0
        AnimationTime = ms
        startTime = Now
        Tmr.Start()
    End Sub
    Private Sub Tmr_Tick() Handles Tmr.Tick
        ProgressBar1.Value = Math.Min((Now - startTime).TotalMilliseconds / AnimationTime, 1) * 100
        If ProgressBar1.Value = 100 Then Tmr.Stop()
    End Sub
