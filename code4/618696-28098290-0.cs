        Public Class AuthenticationHeader
          Implements IClientMessageInspector
       
        Private itsUser As String
        Private itsPass As String
    
        Public Sub New(ByVal user As String, ByVal pass As String)
            itsUser = user
            itsPass = pass
        End Sub
    
        Public Sub AfterReceiveReply(ByRef reply As Message, correlationState As Object) Implements IClientMessageInspector.AfterReceiveReply
            Console.WriteLine("Received the following reply: '{0}'", reply.ToString())
        End Sub
    
        Public Function BeforeSendRequest(ByRef request As Message, channel As IClientChannel) As Object Implements IClientMessageInspector.BeforeSendRequest
            Dim hrmp As HttpRequestMessageProperty = request.Properties("httpRequest")
            Dim encoded As String = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(itsUser + ":" + itsPass))
            hrmp.Headers.Add("Authorization", "Basic " + encoded)
            Return request
          End Function
        End Class
