    Public Class MyFactory 
        Public Shared/Static theStuffICreated as List(Of Stuff)
        Shared/Static Sub New()
            AddHandler AppDomain.CurrentDomain.ProcessExit, AddressOf ApplicationExitHandler 
        End Sub
 
        Public Shared/Static Sub ApplicationExitHandler(ByVal s As Object, e As EventArgs)
            RemoveHandler AppDomain.CurrentDomain.ProcessExit, AddressOf ApplicationExitHandler
            ThingsToDoWhenClassIsDestroyed()
        End Sub 
        Public Shared/Static Sub Create(...) 
             ... 
        End Sub 
     
        Public Shared/Static Sub ThingsToDoWhenClassIsDestroyed() 
             ... 
        End Sub
    End Class 
