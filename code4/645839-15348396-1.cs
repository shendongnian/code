    Public Sub SendEmail([to] As String, subject As String, body As String)
    	Dim mailMessage = New System.Net.Mail.MailMessage()
    	mailMessage.[To].Add([to])
    	mailMessage.Subject = subject
    	mailMessage.Body = body
    
    	Dim smtpClient = New SmtpClient()
    	smtpClient.EnableSsl = True
    	smtpClient.Send(mailMessage)
    End Sub
