    private void SendMailMessage(string emailTo)
    {
        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromAddress);
        message.To.Add(new MailAddress(emailTo));
        message.Subject = "Regarding your lottery winnings";
        message.IsBodyHtml = false;
        string body = "Content-Type: text/plain;charset=\"iso-8859-1\"\nContent-Transfer-Encoding: quoted-printable\n\nBlah blah blah blah blah blah.";                
        byte[] messageBytes = Encoding.ASCII.GetBytes(body);
        ContentInfo content = new ContentInfo(messageBytes);
        SignedCms signedCms = new SignedCms(content, false);
        CmsSigner Signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, emailCert);
        signedCms.ComputeSignature(Signer);
        byte[] signedBytes = signedCms.Encode();
        MemoryStream ms = new MemoryStream(signedBytes);
        AlternateView av = new AlternateView(ms, "application/pkcs7-mime; smime-type=signed-data;name=smime.p7m");
        message.AlternateViews.Add(av);                
        SmtpClient client = new SmtpClient(smtpServer, int.Parse(smtpServerPort));
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.Send(message);
        message.Dispose();
        client = null;
    }
