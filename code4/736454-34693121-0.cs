    <System.Runtime.CompilerServices.Extension>
    Public Function HasAttribute(Of TABLEENTITY, ATTRTYPE)(md As ModelMetadata) As Boolean
        Dim properyName As String = md.ContainerType.GetProperty(md.PropertyName).ToString()
    
        Dim att As MetadataTypeAttribute = DirectCast(Attribute.GetCustomAttribute(GetType(TABLEENTITY), GetType(MetadataTypeAttribute)), MetadataTypeAttribute)
        If att IsNot Nothing Then
            For Each prop In Type.[GetType](att.MetadataClassType.UnderlyingSystemType.FullName).GetProperties()
                If properyName.ToLower() = properyName.ToLower() AndAlso Attribute.IsDefined(prop, GetType(ATTRTYPE)) Then
                    Return True
                End If
            Next
        End If
    
        Return False
    End Function
