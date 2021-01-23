        Public Class Form1
            <System.ComponentModel.TypeConverter(GetType(AudioConverter)), System.ComponentModel.DefaultValue("(none)")>
            Public Property AudioName As String
    
            <System.ComponentModel.Browsable(False)> 'This will make the property not appear in the designer
            Public ReadOnly Property Audio As Stream
                Get
                    If String.IsNullOrWhiteSpace(AudioName) OrElse
                        AudioName = "(none)" Then
                        Return Nothing
                    End If
                    Try
                        Return My.Resources.ResourceManager.GetStream(AudioName)
                    Catch ex As Exception
                        Return Nothing
                    End Try
                End Get
            End Property
        End Class
    
        Public Class AudioConverter
            Inherits System.ComponentModel.TypeConverter
    
            Public Overrides Function GetStandardValuesSupported(context As System.ComponentModel.ITypeDescriptorContext) As Boolean
                Return True
            End Function
    
            ' Set the property to be informed only from predefined (standard) values
            Public Overrides Function GetStandardValuesExclusive(context As System.ComponentModel.ITypeDescriptorContext) As Boolean
                Return True
            End Function
    
            ' Get possible values that will be inserted in the drop-down list
            Public Overrides Function GetStandardValues(context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
    
                Dim returnList As New System.Collections.Generic.List(Of String)
                returnList.Add("(none)")
                For Each resItem As System.Collections.DictionaryEntry In My.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, True, False)
                    Dim resourceEntry As String = resItem.Key
                    If TypeOf resourceEntry Is String Then
                        returnList.Add(resourceEntry)
                    End If
                Next
    
                Return New System.ComponentModel.TypeConverter.StandardValuesCollection(returnList)
            End Function
        End Class
