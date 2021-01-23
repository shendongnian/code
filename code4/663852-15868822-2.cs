    Public Function GetMyTables()
        Try
            Using MCTX As New MyContext()
                Return (
                    From T In MCTX.MyTables
                    Order By T.Name
                    Select New With {
                        T.KeyColumn,
                        T.Name,
                        T.IsActive
                    }).ToArray
            End Using
        Catch ex As Exception
            Return ReportException(
                "An error occurred trying to retrieve the table list", ex)
        End Try
    End Function
