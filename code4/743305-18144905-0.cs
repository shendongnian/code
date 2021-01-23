    <Serializable()> Public Class NotificationMessage
    
        Private myUserData As UserData
    
        Public Sub New()
            myUserData = New UserData()
        End Sub
    
        <System.Xml.Serialization.XmlElementAttribute("UserData")> _
        Public Property UserData() As UserData
            Get
                Return Me.myUserData
            End Get
            Set(value As UserData)
                Me.myUserData = value
            End Set
        End Property
    
    End Class
    
    <Serializable()> Public Class UserData
    
        Private anyField As List(Of System.Xml.XmlElement)
    
        Public Sub New()
            Me.anyField = New List(Of System.Xml.XmlElement)()
        End Sub
    
        <XmlAnyElementAttribute()>
        Public Property Any() As List(Of System.Xml.XmlElement)
            Get
                Return Me.anyField
            End Get
            Set(value As List(Of System.Xml.XmlElement))
                Me.anyField = value
            End Set
        End Property
    End Class
