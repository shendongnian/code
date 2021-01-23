    Namespace Company.Data
      Public Enum EyeColor As Int16
        Unknown = 0
        Brown = 1
        Blue = 2
        Green = 3
      End Enum
    
      Public Enum HairColor As Int16
        Unknown = 0
        Brown = 1
        Blond = 2
        Red = 3
        Pink = 4
      End Enum
    End Namespace
    
    
    
    Public Class Person
    
      Public Property EyeColor As EyeColor = EyeColor.Unknown
    
      Public Property HairColor As HairColor = HairColor.Unknown
    
    End Class
