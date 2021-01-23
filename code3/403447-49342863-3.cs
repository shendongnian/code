    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        DataGridView1.AutoGenerateColumns = True
        Me.DataGridView1.DataSource = MyObservableQueueList
        AddHandler MyObservableQueueList.CollectionChanged, AddressOf UpdateGrid
    End Sub
    Private Sub UpdateGrid(sender As Object, e As System.Collections.Specialized.NotifyCollectionChangedEventArgs)
        Me.MyObservableQueueList.DataSource = Nothing
        Me.MyObservableQueueList.DataSource = _AlarmHistory
    End Sub
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            RemoveHandler MyObservableQueueList.CollectionChanged, AddressOf UpdateGrid
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
