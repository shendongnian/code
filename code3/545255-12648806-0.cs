    Public Class Form1
    
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim entries As List(Of AccountEntry) = RetrieveEntries()
    
            DataGridView1.DataSource = entries
    
        End Sub
    
        Public Class AccountEntry
            Public Property Id As Integer
            Public Property Debit As Nullable(Of Decimal)
            Public Property Credit As Nullable(Of Decimal)
            Public Property EntryDate As DateTime
        End Class
    
        Public Function RetrieveEntries() As List(Of AccountEntry)
            Dim returnEntries As List(Of AccountEntry) = Nothing
            ' Do your database stuff here to retrieve a list of AccountEntry'
            Return returnEntries
        End Function
    
    End Class
