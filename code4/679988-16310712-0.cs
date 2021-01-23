    Sub ExampleUsage()
        Dim ds as new dataset
        ExecuteDataSetFill(AnSqlConnection, "SELECT * FROM Something; SELECT * from SomethingElse", ds)
        Dim Tbl1 as datatable=ds.Tables(0)
        Dim Tbl2 as datatable=ds.Tables(1)
        ' both tables will ALREADY HAVE all the rows in them, there is no reader involved.
    End Sub
		''' <summary>
		''' Performs a FILL operation on an adapter, populating the passed in dataset for the current "OpenConnection", returns the return value of the FILL command.
		''' </summary>
		''' <param name="sSQL">SQL to use for the command to issue</param>
		''' <param name="dsToFill">a DataSet to FILL</param>
		''' <returns>The Return Value of the FILL operation</returns>
		Public Overridable Function ExecuteDataSetFill(ByVal con As SqlClient.SqlConnection, ByVal sSQL As String, ByVal dsToFill As DataSet) As Integer
			Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter
			Dim com As SqlClient.SqlCommand = con.CreateCommand
			com.CommandText = sSQL
			da.SelectCommand = com
			Dim iOut As Integer
			dsToFill.EnforceConstraints = False
			Dim sw As Stopwatch = Stopwatch.StartNew
			Try
				iOut = da.Fill(dsToFill)
			Catch ex As Exception
				Throw New Exception("DataSet Error. " & vbCrLf & "SQL = " & sSQL & vbCrLf & "Error=" & ex.ToString, ex)
			End Try
			sw.Stop()
			Return iOut
		End Function
