    <DataContract> 
    Public Class Customer 
    
    <DataMember(Name:="Status")> 
    Public Property Status As Int32 
    
    <DataMember> 
    Public Property Information As Object 
    
    <DataMember> 
    Public Property CustomerId As String 
    
    End Class 
    
    
    
    
    Public Class Customers 
    
    Public Property CustomerStatuses As List(Of Customer) 
    
    End Class
