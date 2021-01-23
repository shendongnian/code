    Namespace Migrations
      Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of BlogContext)
        Public Sub New()
          Me.AutomaticMigrationsEnabled = False
        End Sub
        Protected Overrides Sub Seed(Context As BlogContext)
        End Sub
      End Class
    End Namespace
