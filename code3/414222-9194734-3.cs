    Imports System.Xml.Serialization
    Imports SharedLibrary
    Public Class Form1
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim client As New ServiceReference1.WebServiceSoapClient
        Dim a As New Animal
        a.Name = "Pooh"
        MessageBox.Show(client.SendObject(XmlSerialize(a), ServiceReference1.ObjectT.Animal))
        Dim v As New Vehicle
        v.Name = "Volvo"
        MessageBox.Show(client.SendObject(XmlSerialize(v), ServiceReference1.ObjectT.Vehicle))
    End Sub
    Public Shared Function XmlSerialize(ByVal serializableObject As Object) As Byte()
        Dim serializer As XmlSerializer = New XmlSerializer(serializableObject.GetType())
        Dim aMemStr As New System.IO.MemoryStream
        Dim writer As System.Xml.XmlWriter = System.Xml.XmlWriter.Create(aMemStr)
        serializer.Serialize(writer, serializableObject)
        writer.Close()
        aMemStr.Close()
        Return aMemStr.ToArray()
    End Function
