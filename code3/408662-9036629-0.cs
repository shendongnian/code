    Module Module1
    
        Sub main()
            Dim List As New List(Of String) From {"Joe", "Ken", "Bob", "John"}
            Dim Search As String = "*Jo*"
            Dim Result = List.FindName(Search)
        End Sub
    
    
    End Module
    
    Public Module Extensions
    
        <System.Runtime.CompilerServices.Extension()>
        Public Function FindName(List As IEnumerable(Of String), Search As String) As IEnumerable(Of String)
    
            Return List.Where(Function(Name) Name Like Search)
    
        End Function
    
    End Module
