    Imports System.Configuration
    Imports System.Data.Entity
    Imports System.Collections.Specialized
    
    Imports Oracle.DataAccess.Client
    Imports System.Reflection
    
    Public Class MyContext
        Inherits System.Data.Entity.DbContext
    
        Public Property MyTables As DbSet(Of MyTable)
        
        Public Sub New()
            MyBase.New(
                New OracleConnection(
                    ConfigurationManager.ConnectionStrings(
                        "Entities").ConnectionString
                    ),
                True
            )
        End Sub
    
    End Class
