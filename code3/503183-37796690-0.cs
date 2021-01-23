    Private LastRowAdditionCanceled As Boolean
    
        Public Sub RowChanging(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
    
             If e.Action = DataRowAction.Add Then
    		'Add the conditions where you want to cancel the row addition above
     		LastRowAdditionCanceled = True
              End If
        End Sub
    
    
    
        Public Sub RowChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
    
              If LastRowAdditionCanceled = False Then
              	 'execute your usual RowChanged code here
    
              Else
                    e.Row.RejectChanges()
                    LastRowAdditionCanceled = False
              End If
        End Sub
