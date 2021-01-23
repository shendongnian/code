    Public Sub ChangeList(newLineList As IEnumerable)
    	If InvokeRequired Then
    
    		BeginInvoke(DirectCast(Function(t, e1) t.ChangeList(e1), Action(Of MainForm, IEnumerable(Of LineInfo))), Me, newLineList)
    		Return
    	End If
    
    End Sub
