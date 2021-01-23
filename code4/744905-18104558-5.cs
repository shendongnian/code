    Dim q = From c In Me.DataGridView1.Columns.Cast(Of DataGridViewColumn)() Order By c.DisplayIndex Select c
    For Each column In q
            If column.Visible Then
                Console.WriteLine(column.HeaderText.ToString())
            End If
    Next
