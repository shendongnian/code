     Private Sub DataGridView1_CellContentClick(sender As Object, e As 
     DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim _ColumnIndex As Integer = e.ColumnIndex
        Dim _RowIndex As Integer = e.RowIndex
        'Uses reverse logic for current cell because checkbox checked occures 
         'after click
        'If you know current state is False then logic dictates that a click 
         'event will set it true
        'With these 2 check boxes only one can be true while both can be off
        If DataGridView1.Rows(_RowIndex).Cells("Column2").Value = False And 
           DataGridView1.Rows(_RowIndex).Cells("Column3").Value = True Then
            DataGridView1.Rows(_RowIndex).Cells("Column3").Value = False
        End If
        If DataGridView1.Rows(_RowIndex).Cells("Column3").Value = False And 
        DataGridView1.Rows(_RowIndex).Cells("Column2").Value = True Then
            DataGridView1.Rows(_RowIndex).Cells("Column2").Value = False
        End If
    End Sub
