     Private Sub DynList_RowValidated(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
            If ChangedRow = True Then
                ChangedRow = False
                'Row Changed...
            End If
    
     End Sub
     Dim ChangedRow As Boolean
     Private Sub DynList_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
            ChangedRow = True
     End Sub
