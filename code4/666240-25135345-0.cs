    Public Class BlogContext
      Inherits DbContext
      Public Sub New()
        Database.Connection.ConnectionString = Utils.SqlCeConnection.ConnectionString
      End Sub
      Private Sub New(Connection As DbConnection)
        MyBase.New(Connection, True)
        Database.SetInitializer(New MigrateDatabaseToLatestVersion(Of BlogContext, Migrations.Configuration))
        Database.Initialize(True)
      End Sub
      Public Shared Function Create() As BlogContext
        Return New BlogContext(Utils.SqlCeConnection)
      End Function
      Public Property Blogs As DbSet(Of Blog)
    End Class
