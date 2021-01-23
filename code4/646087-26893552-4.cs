    Public Class EmitDefaultValuesAttribute
        Inherits Attribute
        Private Shared mCache As New Dictionary(Of Assembly, XmlAttributeOverrides)
        Public Shared Function GetOverrides(assembly As Assembly) As XmlAttributeOverrides
            If mCache.ContainsKey(assembly) Then Return mCache(assembly)
            Dim xmlOverrides As New XmlAttributeOverrides
            For Each t In assembly.GetTypes()
                If t.GetCustomAttributes(GetType(EmitDefaultValuesAttribute), True).Count > 0 Then
                    AddOverride(t, xmlOverrides)
                End If
            Next
            mCache.Add(assembly, xmlOverrides)
            Return xmlOverrides
        End Function
        Private Shared Sub AddOverride(t As Type, xmlOverrides As XmlAttributeOverrides)
            For Each prop In t.GetProperties()
                Dim defaultAttr = prop.GetCustomAttributes(GetType(DefaultValueAttribute), True).FirstOrDefault()
                Dim xmlAttr As XmlAttributeAttribute = prop.GetCustomAttributes(GetType(XmlAttributeAttribute), True).FirstOrDefault()
                If defaultAttr IsNot Nothing AndAlso xmlAttr IsNot Nothing Then
                    Dim attrs As New XmlAttributes '= {New XmlAttributeAttribute}
                    attrs.XmlAttribute = xmlAttr
                    ''overide.Add(t, xmlAttr.AttributeName, attrs)
                    xmlOverrides.Add(t, prop.Name, attrs)
                End If
            Next
        End Sub
        
