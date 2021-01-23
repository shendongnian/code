    Sub Main(args As String())
        AddHandler AppDomain.CurrentDomain.FirstChanceException, AddressOf FirstChanceExceptionEventHandler
        Throw New Exception("Exception thrown in main.")
    End Sub
    Private Sub FirstChanceExceptionEventHandler(ByVal source As Object, ByVal e As FirstChanceExceptionEventArgs)
        On Error Resume Next
        Dim frames As StackFrame() = New StackTrace(1).GetFrames()
        Dim currentMethod As MethodBase = MethodBase.GetCurrentMethod()
        If frames IsNot Nothing AndAlso frames.Any(Function(x) x.GetMethod() = currentMethod) Then
            Return
        Else
            Throw New Exception("Stackoverflow")
        End If
    End Sub
