    Private ReadOnly Property ViewModel As MyViewModel
        Get
            Return DirectCast(DataContext, MyViewModel)
        End Get
    End Property
    Private Sub MyView_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If ViewModel.SelectedItems Is Nothing Then
            ViewModel.SelectedItems = MyDataGrid.SelectedItems 
        End If
    End Sub
