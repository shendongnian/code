    Imports Newtonsoft.Json
    Public Class MyBooleanConverter
        Inherits JsonConverter
    Public Overrides ReadOnly Property CanWrite As Boolean
        Get
            Return True
        End Get
    End Property
 
    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        Dim boolVal As Boolean = value
        writer.WriteValue(If(boolVal, 1, 0))
    End Sub
    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
        Dim value = reader.Value
        If IsNothing(value) OrElse String.IsNullOrWhiteSpace(value.ToString()) OrElse "0" = value Then
            Return False
        End If
        If 0 = String.Compare("yes", value, True) OrElse 0 = String.Compare("true", value, True) Then
            Return True
        End If
        Return False
    End Function
    Public Overrides Function CanConvert(objectType As Type) As Boolean
        Return objectType = GetType(Boolean) OrElse objectType = GetType(Boolean?) 'OrElse objectType = GetType(String)
    End Function
    End Class
