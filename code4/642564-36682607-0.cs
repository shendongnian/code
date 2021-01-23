    Imports System
    Imports System.Data.Entity
    Imports System.Data.Entity.Migrations
    Imports System.Linq
    
    Namespace Migrations
    
        Friend NotInheritable Class Configuration 
            Inherits DbMigrationsConfiguration(Of DAL.MyDbContext)
    
            Public Sub New()
                AutomaticMigrationsEnabled = False
                AutomaticMigrationDataLossAllowed = False
            End Sub
    
            Protected Overrides Sub Seed(context As DAL.MyDbContext)
                '  This method will be called after migrating to the latest version.
    
                Dim newContext As New MyDbContext(context.Database.Connection.ConnectionString)
                Using ts = newContext.Database.BeginTransaction()
    
                    Try
    
                        ' Turn on identity insert before updating
                        newContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT GoogleApiTypeGroups ON")
                        ' Make sure the expected GoogleApiTypeGroups exist with the correct names and IDs.
                        newContext.GoogleApiTypeGroups.AddOrUpdate(
                            Function(x) x.Id,
                            New GoogleApiTypeGroup() With {.Id = 1, .name = "Google Cloud APIs"},
                            New GoogleApiTypeGroup() With {.Id = 2, .name = "YouTube APIs"},
                            New GoogleApiTypeGroup() With {.Id = 3, .name = "Google Maps APIs"},
                            New GoogleApiTypeGroup() With {.Id = 4, .name = "Advertising APIs"},
                            New GoogleApiTypeGroup() With {.Id = 5, .name = "Google Apps APIs"},
                            New GoogleApiTypeGroup() With {.Id = 6, .name = "Other popular APIs"},
                            New GoogleApiTypeGroup() With {.Id = 7, .name = "Mobile APIs"},
                            New GoogleApiTypeGroup() With {.Id = 8, .name = "Social APIs"})
                        ' Attempt to save the changes.
                        newContext.SaveChanges()
                        ' Turn off the identity insert setting when done.
                        newContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT GoogleApiTypeGroups OFF")
    
                        ' Turn on identity insert before updating
                        newContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT GoogleApiTypes ON")
                        ' Make sure the expected GoogleApiTypes exist with the correct names, IDs, and references to their corresponding GoogleApiTypeGroup.
                        newContext.GoogleApiTypes.AddOrUpdate(
                            Function(x) x.Id,
                            New GoogleApiType() With {.Id = 1, .name = "Google Maps JavaScript API", .GoogleApiTypeGroupId = 3})
                        ' Save the changes
                        newContext.SaveChanges()
                        ' Turn off the identity insert setting when done.
                        newContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT GoogleApiTypes ON")
    
                        ts.Commit()
                    Catch ex As Exception
                        ts.Rollback()
                        Throw
                    End Try
                End Using
    
            End Sub
    
        End Class
    
    End Namespace
