        Private Sub SetTypeNameForTableParameter(ByRef parameter As System.Data.SqlClient.SqlParameter)
            If parameter.SqlDbType = SqlDbType.Structured Then
                Dim name As String = parameter.TypeName
                Dim index As Integer = name.IndexOf(".")
                If index <> -1 Then
                    name = name.Substring(index + 1)
                    If name.Contains(".") Then
                        parameter.TypeName = name
                    End If
                End If
            End If
        End Sub
