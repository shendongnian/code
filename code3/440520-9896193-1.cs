    Public Class JSsetTimeout
    
        Dim res As Object = Nothing
        Dim WithEvents tm As Timer = Nothing
        Dim _obj As Threading.ThreadStart
        Dim _args() As Object
    
        Public Shared Sub SetTimeout(ByVal obj As Threading.ThreadStart, ByVal TimeSpan As Integer) ', ByVal ParamArray args() As Object)
            Dim jssto As New JSsetTimeout(obj, TimeSpan) ', args)
        End Sub
    
        Public Sub New(ByVal obj As Threading.ThreadStart, ByVal TimeSpan As Integer, ByVal ParamArray args() As Object)
            If obj IsNot Nothing Then
                _obj = obj
                _args = args
                tm = New Timer With {.Interval = TimeSpan, .Enabled = False}
                AddHandler tm.Tick, AddressOf tm_Tick
                tm.Start()
            End If
        End Sub
    
        Private Sub tm_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tm.Tick
            tm.Stop()
            If _obj IsNot Nothing Then
                res = _obj.DynamicInvoke(_args)
            Else
                res = Nothing
            End If
        End Sub
    End Class
