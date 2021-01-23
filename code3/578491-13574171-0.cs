    Imports System.Configuration
    Imports System.Reflection
    Public Class AppConfig
      Implements IDisposable
      Public Shared Function Change(ByVal path As String) As AppConfig
    
        Return New ChangeAppConfig(path)
      End Function
      Public Overridable Sub Dispose() Implements IDisposable.Dispose
      End Sub
      Private Class ChangeAppConfig
        Inherits AppConfig
        Private ReadOnly oldConfig As String = AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE").ToString
        Private disposedValue As Boolean
        Public Sub New(ByVal path As String)
          AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", path)
          ResetConfigMechanism()
        End Sub
        Public Overrides Sub Dispose()
          If (Not disposedValue) Then
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", oldConfig)
            ResetConfigMechanism()
            disposedValue = True
          End If
          GC.SuppressFinalize(Me)
        End Sub
        Private Shared Sub ResetConfigMechanism()
    
          GetType(ConfigurationManager).GetField("s_initState", BindingFlags.NonPublic Or BindingFlags.Static).SetValue(Nothing, 0)
          GetType(ConfigurationManager).GetField("s_configSystem", BindingFlags.NonPublic Or BindingFlags.Static).SetValue(Nothing, Nothing)
          Dim assemblies() As Type = GetType(ConfigurationManager).Assembly.GetTypes()
          For Each assembly As Type In assemblies
            If (assembly.FullName = "System.Configuration.ClientConfigPaths") Then
              assembly.GetField("s_current", BindingFlags.NonPublic Or BindingFlags.Static).SetValue(Nothing, Nothing)
              Exit For
            End If
          Next
        End Sub
      End Class
    End Class
