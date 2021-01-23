    Private Sub btngo_Click(sender As Object, e As RoutedEventArgs) Handles btnGo.Click
        PerformNextAction(actions(0))
    End Sub
    Private Sub go_stright()
        Dim da As New DoubleAnimation(offsety, offsety - 50, New Duration(TimeSpan.FromSeconds(1)))
        offsety -= 50
        Dim tt As New TranslateTransform()
        AddHandler da.Completed, AddressOf AnimationCompleted
        tt.BeginAnimation(TranslateTransform.YProperty, da)
    End Sub
    
    Private Sub AnimationCompleted(sender As Object, e As EventArgs)
        If actionCounter < 4 Then
            actionCounter += 1
            PerformNextAction(actions(actionCounter))
        End If
    End Sub
    
    Private Sub PerformNextAction(ByVal action As Action)
        Select Case action
            Case MainWindow.Action.GoStraight
                go_stright()
            Case MainWindow.Action.RotateLeft
                rotate_left()
            Case MainWindow.Action.RotateRight
                rotate_right()
        End Select
    End Sub
