    Imports Newtonsoft.Json
    Public Class MyBooleanConverter
        Inherits JsonConverter
    Public Overrides ReadOnly Property CanWrite As Boolean
        Get
            Return False
        End Get
    End Property
 
    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        Throw New NotImplementedException()
    End Sub
    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
        Dim value = reader.Value
        If (IsNothing(value) OrElse String.IsNullOrWhiteSpace(value.ToString())) Then
            Return False
        End If
        If 0 = String.Compare("yes", value, True) Then
            Return True
        End If
        Return False
    End Function
    Public Overrides Function CanConvert(objectType As Type) As Boolean
        If objectType = GetType(String) OrElse objectType = GetType(Boolean) Then
            Return True
        End If
        Return False
    End Function
    End Class
