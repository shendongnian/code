     Public Class ObjectTypes
      Public Enum ObjectT
        Animal
        Vehicle
       End Enum
      End Class
      Public Class Animal
    Private strName As String
    Public Property Name As String
        Get
            Return strName
        End Get
        Set(value As String)
            strName = value
        End Set
    End Property
    End Class
    Public Class Vehicle
    Private strName As String
    Public Property Name As String
        Get
            Return strName
        End Get
        Set(value As String)
            strName = value
        End Set
    End Property
    End Class
