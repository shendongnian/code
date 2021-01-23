    public string EnviarMensaje(int intIdVendedor, string strCorreoPara, string strCorreosAdicionales, string strTema, string strMensaje, string strRuta)
        {
			string strResultado="";
            DataTable dt = ConexionBD.GetInstanciaConexionBD().GetVendedorEspecifico(intIdVendedor);
            string strCuerpo = strMensaje + "\n\n\n\nMensaje Enviado Por:\n" + dt.Rows[0]["Vendedor"] + "\n" + dt.Rows[0]["Email"] + "\n" + dt.Rows[0]["Telefono"];
            string[] strListaCorreos = strCorreosAdicionales.Split(new Char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtpout.secureserver.net");
                mail.Subject = strTema;
                mail.Body = strCuerpo;
                mail.From = new MailAddress(strCorreoDe);
                mail.To.Add(strCorreoPara);
                foreach (string c in strListaCorreos)
                {
                    mail.To.Add(c);
                }
                bool hasAttachment = !string.IsNullOrWhitespace(strRuta);
                System.IO.FileStream stream = null;
                Attachment attachment = null;
                if (hasAttachment)
                {
                    // Create a file stream.
                    stream = new FileStream(strRuta, FileMode.Open, FileAccess.Read);
                    // Define content type.
                    ContentType contentType = new ContentType();
                    contentType.MediaType = MediaTypeNames.Text.Plain; // or whatever your attachment is
                    // Create the attachment and add it.
                    attachment = new Attachment(stream, contentType);
                    mail.Attachments.Add(attachment);
                }
                SmtpServer.Port = 80;
                SmtpServer.Credentials = new System.Net.NetworkCredential(strCorreoDe, strContrasena);
                SmtpServer.EnableSsl = false;
                SmtpServer.Send(mail);
                strResultado = "Exito";
                // Don't forget to release the resources if the attachment has been added
                if (hasAttachment)
                {
                    data.Dispose();
                    stream.Close();
                    stream.Dispose();
                }
            }
            catch (Exception ex)
            {
                strResultado = ex.ToString();
            }
            return strResultado;
        }
