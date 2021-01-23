        Dim test As String = "string1, string2, string3, string4"
        With MyDBConnection
            Dim transaction As OleDbTransaction
            Try
                Call .Open()
                transaction = .BeginTransaction()
                With .CreateCommand()
                    .Transaction = transaction
                    For Each entry As String In test.Split(","c)
                        .CommandText = String.Format("INSERT INTO [Table] ([Column]) VALUES ({0})", entry)
                        Call .ExecuteNonQuery()
                    Next
                End With
                Call transaction.Commit()
            Catch ex As Exception
                ' Handle exception here
                Call transaction.Rollback()
            Finally
                Call .Close()
            End Try
        End With
