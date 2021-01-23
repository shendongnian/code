        AddHandler node.MouseEnter, _
            Sub()
                If node Is Nothing Then
                    node.BeginStoryboard(DirectCast(FindResource("NodeFadeIn"), System.Windows.Media.Animation.Storyboard))
                End If
            End Sub
