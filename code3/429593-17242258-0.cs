    Protected Sub gv_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs)
        Dim intValCount As Integer = Integer.Parse(e.NewValues.Count)
        If intValCount > 0 Then
            Dim i As Integer = 0
            For i = 0 To intValCount - 1
                If Not e.OldValues(i).Equals(e.NewValues(i)) Then
                    ' values have changed, audit the change
                    Sys.Audits.General(intID, "the_database_table", <the table field by index(i)>, e.OldValues(i).ToString, e.NewValues(i).ToString)
                End If
                i += 1
            Next
        End If
    End Sub
