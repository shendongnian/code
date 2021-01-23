        Imports MongoDB.Bson
        Imports MongoDB.Bson.Serialization.Attributes    
        Imports MongoDB.Driver
    
    Public Class _default
        Inherits System.Web.UI.Page
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  
            Dim objMongo As New MongoClient("mongodb://192.168.111.5:27017")
            Dim objDatabase As IMongoDatabase = objMongo.GetDatabase("local")
            Dim objCollection = objDatabase.GetCollection(Of BsonDocument)("Test")            
            Dim _ret As New List(Of mongo_users)
    
            Dim result = objCollection.Find(New BsonDocument()).ToList()
            Dim _json_response = result.ToJson()
            If _json_response <> "" Then
    
                _ret = MongoDB.Bson.Serialization.BsonSerializer.Deserialize(Of List(Of mongo_users))(_json_response)
    
            End If
    
            For Each item In _ret
                Response.Write(item.name & " " & item.last_name & "</br>")
            Next
    
    
        End Sub
    
    End Class
    
    Public Class mongo_users            
        <BsonId>
        <BsonRepresentation(BsonType.ObjectId)>
        Public Property _id() As String
        Public Property status As Integer
        Public Property name As String
        Public Property last_name As String
        Public Property colors As List(Of user_colors)    
    End Class
    
    Public Class user_colors
        Public Property color_name As String
    End Class
