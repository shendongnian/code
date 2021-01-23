    <WebMethod()> _
    Public Function SendObject(bytObject As Byte(), objType As SharedLibrary.ObjectTypes.ObjectT) As String
        Try
            Select Case objType
                Case ObjectTypes.ObjectT.Animal
                    Dim myAnimal As Animal = XmlDeSerialize(bytObject, GetType(Animal))
                    Return "I received an animal with name: " & myAnimal.Name
                Case ObjectTypes.ObjectT.Vehicle
                    Dim myVehicle As Vehicle = XmlDeSerialize(bytObject, GetType(Vehicle))
                    Return "I received a vehicle with name: " & myVehicle.Name
            End Select
        Catch ex As Exception
            Return "Something went wrong: " & ex.Message
        End Try
        Return "I did not receive anything :("
    End Function
    Public Shared Function XmlDeSerialize(ByVal xmlbytearr As Byte(), ByVal objectType As Type) As Object
        Dim serializer As XmlSerializer = New XmlSerializer(objectType)
        Dim aStream As System.IO.MemoryStream = New System.IO.MemoryStream(xmlbytearr)
        Return serializer.Deserialize(aStream)
    End Function
