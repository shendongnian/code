      Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
                If String.IsNullOrEmpty(txtMSG.Text.Trim) Then Return
                   SendSMS()
                
       End Sub
      Private Sub SendSMS()
         Try
              If Not mymodem.IsOpen Then connect()
              Dim pdu As New SmsSubmitPdu(txtMSG.Text.Trim & vbCr, txtTel.Text)
              mymodem.SendMessage(pdu)
              richTextBox1.AppendText("your message sent successfully")
          Catch ex As Exception
              richTextBox1.AppendText(ex.Message)
         End Try
      End Sub
