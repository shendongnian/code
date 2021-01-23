    Imports System.Runtime.Serialization
    Imports System.ServiceModel
    <DataContract()> _
    Public Class MyClass
        <DataMember(order:=1)> _
        Public Property SomeData() As String
        <DataMember(order:=2)> _
        Public Property SomeOtherData() As String
    End Class
