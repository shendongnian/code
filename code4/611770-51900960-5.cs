    Public Shared Function Get_List(ByVal Param1 As String) As List(Of Stored_Procedure_Code_Result)
    Try
     
    Dim Object_List_Result As List(Of Stored_Procedure_Code_Result) = Nothing
     
    Using dbContext As New ExampleModelEntities(Configuration.CONNECTION_STRING)
     
    Object_List_Result = dbContext.Stored_Procedure_Code(Param1).ToList
     
    dbContext.Dispose()
    End Using
    Return Object_List_Result
     
    Catch ex As Exception
    Throw ex
    End Try
     
    End Function
