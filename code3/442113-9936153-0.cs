    Public NotInheritable Class ServiceProxySingleton
     Private Sub New()
     End Sub
     Public Shared Function GetInstance() As ServiceProxySingleton
       Return NestedSingletonService._instance
     End Function
      ' Internal class
      Class NestedSingletonService
        Friend Shared ReadOnly _instance As [SingletonClass] = New [SingletonClass]()
        Shared Sub New()
        End Sub
      End Class
    End Class
