    Public Class LocalStorage
        Implements ILocalStorage
    
        Private Const _CompanyUrl As String = "http://www.mycompany.com"
    
        Public Function Read(Of T)(ByVal fileName As String) As T
            Dim contents As T = Nothing
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))
            Try
                Using stream As Stream = New IsolatedStorageFileStream(fileName, FileMode.Open, FileAccess.Read, GetStorage())
                    Using xmlReader As XmlReader = New XmlTextReader(stream)
                        contents = CType(serializer.Deserialize(xmlReader), T)
                    End Using
                End Using
            Catch ex As FileNotFoundException
            Catch ex As Exception
                Throw New IOException("Failed to read from " + fileName + " in local isolated storage", ex)
            End Try
            Return contents
        End Function
    
        Public Sub Write(Of T)(ByVal fileName As String, ByVal serializableDataObject As T)
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))
            Try
                Using stream As Stream = New IsolatedStorageFileStream(fileName, FileMode.Create, FileAccess.Write, GetStorage())
                    Using xmlTextWriter As XmlTextWriter = New XmlTextWriter(stream, New UTF8Encoding(False))
                        xmlTextWriter.Formatting = Formatting.Indented
                        Dim namespaces As XmlSerializerNamespaces = New XmlSerializerNamespaces()
                        namespaces.Add("", "")
                        serializer.Serialize(xmlTextWriter, serializableDataObject, namespaces)
                    End Using
                End Using
            Catch ex As Exception
                Throw New IOException("Failed to write to " & fileName & " in local isolated storage", ex)
            End Try
        End Sub
    
        Private Function GetStorage() As IsolatedStorageFile
            Return IsolatedStorageFile.GetStore(IsolatedStorageScope.Machine Or IsolatedStorageScope.Assembly, Nothing, New Url(_CompanyUrl))
        End Function
    End Class
