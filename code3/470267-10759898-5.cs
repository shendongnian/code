    Public Class MyResourceManager
        Inherits ResourceManager
    
        Public Property BaseResourceManager As ResourceManager
        Public Property BaseResourceManagerType As Type
        Public Property MyResourceManager As ResourceManager = My.Resources.ResourceManager
    
        Public Sub New()
            MyBase.New()
    
            'get a reference to the resource manager for the base application to keep it around'
            Dim ass As Assembly = Assembly.Load("BaseApplication")
            BaseResourceManagerType = ass.GetType("BaseApplication.My.Resources.Resources")
            BaseResourceManager = ReflectionHelper.GetStaticPropertyValue(BaseResourceManagerType, "ResourceManager")
        End Sub
    
        Public Overrides Function GetString(ByVal name As String) As String
            Dim ret As String = MyResourceManager.GetString(name)
            If ret IsNot Nothing Then
                Return ret
            Else
                Return BaseResourceManager.GetString(name)
            End If
        End Function
    
        ... <override all the other members of ResourceManager in the same fashion as above>
    End Class
