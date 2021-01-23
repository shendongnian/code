    Imports System.IO
    Imports System.Xml
    Imports System.Xml.Serialization
    
    Public Module Module1
    
        Public Sub Main()
            Dim serializer = New XmlSerializer(GetType(VehicleDetails))
            Dim xml = "<result>             <Type>MAZDA</Type>             <Make>RX-8</Make>             <Country>JAPAN</Country>         </result>"
    
            Using reader = New StringReader(xml)
                Using xmlReader__1 = XmlReader.Create(reader)
                    Dim result = DirectCast(serializer.Deserialize(xmlReader__1), VehicleDetails)
                    Console.WriteLine(result.Country.Name)
                End Using
            End Using
        End Sub
    
        <XmlRoot("result")> _
        Public Class VehicleDetails
    
            Public Property Type() As String
                Get
                    Return m_Type
                End Get
                Set(value As String)
                    m_Type = value
                End Set
            End Property
            Private m_Type As String
    
    
            Public Property Make() As String
                Get
                    Return m_Make
                End Get
                Set(value As String)
                    m_Make = value
                End Set
            End Property
            Private m_Make As String
            Public Property Country() As Country
                Get
                    Return m_Country
                End Get
                Set(value As Country)
                    m_Country = value
                End Set
            End Property
            Private m_Country As Country
    
        End Class
        Public Class Country
            <XmlText()> _
            Public Property Name() As String
                Get
                    Return m_Name
                End Get
                Set(value As String)
                    m_Name = value
                End Set
            End Property
            Private m_Name As String
        End Class
    
    End Module
