    Sub ShowMeTheTargets(ByVal tRoot As Object, ByVal tLevel As Int32)
    
    		Dim tCount As Int64 = 0
    		Dim tCountName As String = "Length"
    
    		If Nothing Is tRoot Then
    			Exit Sub
    		End If
    
    		If tRoot.GetType Is GetType(Target) Then
    			RTB.AppendText("Found: " & CType(tRoot, Target).Name & vbCrLf)
    			'
    			'	Assume Target is not a Target container.
    			'
    			Exit Sub
    		End If
    
    		If LEVEL_MAX = tLevel Then
    			'
    			'	We don't want to scan this object graph any deeper
    			'
    			Exit Sub
    		End If
    
    		If (Nothing Is tRoot.GetType.GetInterface("IEnumerable")) Then
    			For Each tProperty As PropertyInfo In tRoot.GetType.GetProperties
    				ShowMeTheTargets(tProperty.GetValue(tRoot, Nothing), tLevel + 1)
    			Next
    		Else
    			For Each tObject As Object In tRoot
    				ShowMeTheTargets(tObject, tLevel + 1)
    			Next
    			RTB.AppendText(tCount & vbCrLf)
    		End If
    	End Sub
