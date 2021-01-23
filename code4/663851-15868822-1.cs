    Imports System.ComponentModel.DataAnnotations
    Imports System.ComponentModel.DataAnnotations.Schema
    
    Public Class MyTable
          
        <Key()>
        <Required()>
        Public Property KeyColumn As Int64
    
        <StringLength(50)>
        <Column("LegacyColumnName")>
        Public Property Name As String
    
        <StringLength(1000)>
        Public Property Description As String
    
        <Required()>
        Public Property IsActive As Int64
    
        Public Property DateCreated As DateTime?
    
    End Class
