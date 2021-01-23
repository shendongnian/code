    Public Class Form1
       Dim ValueChanged As Boolean
       Dim da As MySqlDataAdapter
       [...]
    Private Sub dgv_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        ValueChanged = True
    End Sub
    //not sure this one is still usefull, i'm still working on this stuff :)
    Private Sub dgv_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.RowValidated
        If ValueChanged Then
            ValueChanged = False
            da.Update(dt)
        End If
    End Sub
    Private Sub dgv_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.SelectionChanged
        If ValueChanged Then
            ValueChanged = False
            Me.Validate()
            da.Update(dt)
        End If
    End Sub
