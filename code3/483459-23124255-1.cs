    <code>Private Sub EndEdit(ByVal sender As System.Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
            If DataGridView1.IsCurrentCellDirty Then
                DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End Sub
        
    <code>
        Private Sub DataGridView1_TextChanged(ByVal sender As System.Object, ByVal e As 
      System.Windows.Forms.DataGridViewCellEventArgs) Handles 
                                     DataGridView1.CellValueChanged
            If e.RowIndex = -1 Then
                isdirty = True
            End If
            
    //All code you want to perform on change event
    
    <code>    End Sub
    </code>
