    Public Class Utils
      Public Shared ReadOnly Property SqlCeConnection As SqlCeConnection
        Get
          Return New SqlCeConnection(ConnectionString)
        End Get
      End Property
      Public Shared ReadOnly Property SqlCeConnection(DataSource As String) As SqlCeConnection
        Get
          Return New SqlCeConnection(ConnectionString(DataSource))
        End Get
      End Property
      Private Shared ReadOnly Property ConnectionString As String
        Get
          Return ConnectionString(DatabasePath)
        End Get
      End Property
      Private Shared ReadOnly Property ConnectionString(DataSource) As String
        Get
          With New SqlCeConnectionStringBuilder
            .MaxDatabaseSize = 4091
            .MaxBufferSize = 1024
            .CaseSensitive = False
            .FlushInterval = 1
            .DataSource = DataSource
            .FileMode = "Read Write"
            .Encrypt = False
            .Enlist = True
            Return .ConnectionString
          End With
        End Get
      End Property
      Public Shared ReadOnly Property DatabasePath As String
        Get
          Return Path.Combine(DatabaseFolder, DatabaseFile)
        End Get
      End Property
      Public Shared ReadOnly Property DatabaseFile As String
        Get
          Return "MigrationsDemo.sdf"
        End Get
      End Property
      Public Shared ReadOnly Property DatabaseFolder As String
        Get
          DatabaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MigrationsDemo")
          If Not Directory.Exists(DatabaseFolder) Then
            Directory.CreateDirectory(DatabaseFolder)
          End If
        End Get
      End Property
    End Class
