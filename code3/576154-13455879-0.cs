    Private Function GetDictionaryFromDataRow(dr As DataRow) As Dictionary(Of String, Object)
      Dim dict As New Dictionary(Of String, Object)
      For Each col As DataColumn In dr.Table.Columns
        dict.Add(col.ColumnName, dr.Item(col))
      Next
      Return dict
    End Function
