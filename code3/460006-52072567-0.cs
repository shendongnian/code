        Public Sub SendKey(ByVal key As Key)
         Dim args As New KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
            args.RoutedEvent = Keyboard.KeyDownEvent
            InputManager.Current.ProcessInput(args)
        End Sub
    Private Sub dataGrid_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles dataGrid.PreviewKeyDown
            Dim i As UIElement = e.OriginalSource
            Dim DG As DataGrid = sender
            If (e.Key = Key.Enter Or e.Key = Key.Return) AndAlso i IsNot Nothing Then
                MyBase.OnKeyDown(e)
                DG.CommitEdit()
                SendKey(Key.Tab)
                e.Handled = True
            End If
        End Sub
