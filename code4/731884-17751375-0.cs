    Private IDColumnIndex As Integer      //Class scope - we need to use it in multiple methods
    Public Sub PageLoad() Handles Me.Load //or wherever your databind is happening
        Dim source As New DataTable()
        IDColumnIndex = source.Columns("id").Ordinal   //Gets column index of "ID" column
        view.DataSource = source
        view.DataBind()
    End Sub
    //Hide our "ID" auto-generated column.
    Public Sub view_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles view.RowCreated
        e.Row.Cells(IDColumnIndex).Visible = False
    End Sub
