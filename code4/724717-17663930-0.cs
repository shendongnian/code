    Imports System.ComponentModel
    
    Public Class SerializableExpandableObjectConverter
       Inherits ExpandableObjectConverter
    
       Public Overrides Function CanConvertTo(context As System.ComponentModel.ITypeDescriptorContext, destinationType As System.Type) As Boolean
    
          If destinationType Is GetType(String) Then
             Return False
          Else
             Return MyBase.CanConvertTo(context, destinationType)
          End If
    
       End Function
    
       Public Overrides Function CanConvertFrom(context As System.ComponentModel.ITypeDescriptorContext, sourceType As System.Type) As Boolean
    
          If sourceType Is GetType(String) Then
             Return False
          Else
             Return MyBase.CanConvertFrom(context, sourceType)
          End If
    
       End Function
    
    End Class
