    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Dim sHeader As String = DataGridView1.Columns(e.ColumnIndex).Name
        If ucase(sHeader) = "QUARTER" Then '-------> change this with yours
            If e IsNot Nothing Then
                If e.Value IsNot Nothing Then
                    Try
                        Select case e.Value
                            Case 1 : e.Value = "Q1"
                            Case 2 : e.Value = "Mid Year"
                            Case 3 : e.Value = "Q2"
                            Case 4 : e.Value = "End Year"
                        End Select
                        e.FormattingApplied = True
                    Catch ex As FormatException
                        e.Value = ""
                    End Try
                End If
            End If
        End If
    End Sub
