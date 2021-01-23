     For i As Integer = 0 To grdList2.Columns.Count - 1
      If i <> (grdList2.Columns.Count - 1) Then
       grdList2.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
      Else
       grdList2.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End If
     Next
