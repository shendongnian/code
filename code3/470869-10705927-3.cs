    Dim envelope As New Envelope()
    envelope.Body.Login.USERNAME = "username"
    envelope.Body.Login.PASSWORD = "Sm@rt123"
    Dim stream As MemoryStream = New MemoryStream()
    Dim textWriter As XmlTextWriter = New XmlTextWriter(stream, New System.Text.UTF8Encoding(False))
    Dim serializer As XmlSerializer = New XmlSerializer(GetType(Envelope))
    Dim namespaces As XmlSerializerNamespaces = New XmlSerializerNamespaces()
    namespaces.Add("", "")
    serializer.Serialize(textWriter, envelope, namespaces)
    Dim doc As XmlDocument = New XmlDocument()
    doc.LoadXml(Encoding.UTF8.GetString(stream.ToArray()))
    Dim xmlText As String = doc.SelectSingleNode("Envelope").OuterXml
