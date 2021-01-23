    Public Class SomeClass
    	Public ReadOnly Property Name1 As String
    	Public ReadOnly Property Name2 As String
    	Public Sub New()
    		PrivSub(Name1)
    		Name2 = Name1 & " is now"
    	End Sub
    	Private Sub PrivSub(ByRef n As String)
    		n = System.DateTime.UtcNow.ToLongDateString()
    	End Sub
    End Class
