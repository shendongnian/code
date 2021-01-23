    Public Class Form1    
        
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load    
        
        End Sub    
        
        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick    
        
            Timer1.Stop()    
        
             Dim request As FtpWebRequest = CType(WebRequest.Create(""), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails
    
            request.Credentials = New NetworkCredential("", "")
            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
    
                Using responseStream As Stream = response.GetResponseStream()
                    Using reader As New StreamReader(responseStream)
    
    
                        TextBox1.Text = reader.ReadToEnd
                        TextBox1.Text += vbNewLine 
                        TextBox1.Text += vbNewLine
                        ' Use the + for appending (set the textbox to multiline)
                    End Using
                    
                End Using
    
            End Using    
        
            Timer1.Start()    
        
        End Sub    
    End Class 
