    Imports System.Data.Entity
    Namespace WingtipToys.Models
    Public Class ProductContext
    	Inherits DbContext
    	Public Sub New()
    		MyBase.New("WingtipToys")
    	End Sub
    	Public Property Categories As DbSet(Of Category)
    	Public Property Products As DbSet(Of Product)
    End Class
    End Namespace
