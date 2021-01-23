    Imports System.Xml
    Public Class XSett
    Public xml As XmlDocument
    Public Overloads Function gett(ByVal xp As String)
        Return CType(xml.SelectSingleNode(xp), XmlElement).InnerXml
        'by using inner xml, you can have either text setting 
        'or more markup that you might need for another function
        'your choice.  you could even cast it into another instance
        'of this class
    End Function
    Public Overloads Function gett(ByVal xp As String, ByVal sel As Integer)
        Return CType(xml.SelectNodes(xp)(sel), XmlElement).InnerXml
        'here, you can have multiple and choose the one you want
    End Function
    Public Overloads Sub gett(ByVal xp As String, ByRef col As Collection)
        Dim i As Integer
        Dim nds = xml.SelectNodes(xp)
        For i = 0 To nds.Count - 1
            col.Add(CType(nds(i), XmlElement).InnerXml)
        Next
        'Creted an entire collection of elemens.
        'i used vb's "collection" object, but any collection would do
    End Sub
    Public Overloads Sub sett(ByVal ap As String, ByVal name As String, ByVal data As String)
        'assume add here.
        'ap asks for existing parent element. eg: //guids
        'name ask for name of setting element
        Dim ts = xml.CreateElement(name)
        ts.InnerXml = data
        If ap = "" Then 'we assume document element
            xml.DocumentElement.AppendChild(ts)
        Else
            Dim p = CType(xml.SelectSingleNode(ap), XmlElement)
            p.AppendChild(ts)
        End If
    End Sub
    Public Overloads Sub sett(ByVal xp As String, ByVal sel As Integer, ByVal data As String)
        'just change existing setting
        CType(xml.SelectNodes(xp)(sel), XmlElement).InnerXml = data
    End Sub
    'naturally you can expand infinitely if needed
    End Class
