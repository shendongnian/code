    Public Function DeleteBlankRowsfromDataset(ByRef Dtset As DataSet) As Boolean
        Try
            Dtset.Tables(0).AsEnumerable().Where(Function(row) row.ItemArray.All(Function(field) field Is Nothing Or field Is DBNull.Value Or field.Equals(""))).ToList().ForEach(Sub(row) row.Delete())
            Dtset.Tables(0).AcceptChanges()
            DeleteBlankRowsfromDataset = True
        Catch ex As Exception
            MsgBox("Deleting Blank Records in Dataset Failed")
            DeleteBlankRowsfromDataset = False
        End Try
    End Function
