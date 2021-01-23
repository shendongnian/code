    Imports System.Xml
    Imports System.IO
    Public Class CustomXmlTextWriter
        Inherits XmlTextWriter
        Public Sub New(ByRef baseWriter As TextWriter)
            MyBase.New(baseWriter)
            Formatting = Xml.Formatting.Indented
        End Sub
        Public Overrides Sub WriteEndElement()
            If Not (Me.WriteState = Xml.WriteState.Element) Then
                MyBase.WriteEndElement()
            Else
                Formatting = Xml.Formatting.None
                MyBase.WriteFullEndElement()
                Formatting = Xml.Formatting.Indented
            End If
        End Sub
    End Class
