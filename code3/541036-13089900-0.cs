     Public Function GetMessages(ByVal Issue As Issue) As List(Of Message)
            Dim Res As New List(Of Message)
            If Issue IsNot Nothing Then
                Dim db As New ProjectManagerEntities
                Res.AddRange(From item As Message In db.Messages
                                           Where item.IssueSet_Id = Issue.Id _
                                           Select item)
    
            End If
    
            Return Res
        End Function
