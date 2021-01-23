        Dim hasMultiple As New Dictionary(Of String, Boolean)
        For Each subject As String In arraysub
            If hasMultiple.ContainsKey(subject) Then
                hasMultiple(subject) =  True
            Else
                hasMultiple.Add(subject, False)
            End If
        Next
        Dim output As New List(Of String)
        Dim subCount As New Dictionary(Of String, Integer) 
        For Each subject As String In arraysub
            If Not subCount.ContainsKey(subject) Then
                subCount.Add(subject, 0)
            End If
            subCount(subject) += 1
            If hasMultiple(subject) Then
                output.Add(subject & "_" & subCount(subject))
            Else
                output.Add(subject)
            End If
        Next
