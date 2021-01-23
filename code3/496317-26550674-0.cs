                    Dim s As DataSet = New DataSet()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        Dim tables As New List(Of DataTable)
                        Do
                            Dim table As New DataTable()
                            table.Load(reader)
                            tables.Add(table)
                            s.Tables.Add(table)
                        Loop While Not reader.IsClosed
                        s.Load(reader, LoadOption.OverwriteChanges, tables.ToArray())
                    End Using
