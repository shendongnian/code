    Public Property Clients As DbSet(Of Client)
    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        modelBuilder.HasDefaultSchema("dbo")
    End Sub
    End Class
