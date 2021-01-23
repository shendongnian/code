    public class SmtpCustomAppender : log4net.Appender.SmtpAppender
    {
    	public SmtpCustomAppender()
    		: base()
    	{
    	}
    	public ILayout LayoutSubject { get; set; }
    	public bool IsBodyHtml { get; set; }
    	public string Attachment { get; set; }
    
    	protected override void SendEmail(string messageBody)
    	{
    		// .NET 2.0 has a new API for SMTP email System.Net.Mail
    		// This API supports credentials and multiple hosts correctly.
    		// The old API is deprecated.
    
    		// Create and configure the smtp client
    		SmtpClient smtpClient = new SmtpClient();
    		if (!String.IsNullOrEmpty(this.SmtpHost))
    		{
    			smtpClient.Host = this.SmtpHost;
    		}
    		smtpClient.Port = this.Port;
    		smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    		smtpClient.EnableSsl = this.EnableSsl;
    
    		if (Authentication == SmtpAuthentication.Basic)
    		{
    			// Perform basic authentication
    			smtpClient.Credentials = new System.Net.NetworkCredential(Username, Password);
    		}
    		else if (Authentication == SmtpAuthentication.Ntlm)
    		{
    			// Perform integrated authentication (NTLM)
    			smtpClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
    		}
    
    		using (System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage())
    		{
    			mailMessage.IsBodyHtml = IsBodyHtml;
    			mailMessage.Body = messageBody;
    			//mailMessage.BodyEncoding = BodyEncoding;
    			mailMessage.From = new MailAddress(From);
    			foreach(string emailTo in To.Split(';'))
    				mailMessage.To.Add(emailTo);
    			if (!String.IsNullOrEmpty(Cc))
    			{
    				foreach (string emailCc in Cc.Split(';'))
    					mailMessage.CC.Add(emailCc);
    			}
    			if (!String.IsNullOrEmpty(Bcc))
    			{
    				foreach (string emailBcc in Bcc.Split(';'))
    					mailMessage.Bcc.Add(emailBcc);
    			}
    			if (!String.IsNullOrEmpty(this.ReplyTo))
    			{
    				// .NET 4.0 warning CS0618: 'System.Net.Mail.MailMessage.ReplyTo' is obsolete:
    				// 'ReplyTo is obsoleted for this type.  Please use ReplyToList instead which can accept multiple addresses. http://go.microsoft.com/fwlink/?linkid=14202'
    //#if !NET_4_0
    				//mailMessage.ReplyTo = new MailAddress(this.ReplyTo);
    //#else
    				mailMessage.ReplyToList.Add(new MailAddress(this.ReplyTo));
    //#endif
    			}
    			mailMessage.Subject = this.Subject;
    			//mailMessage.SubjectEncoding = m_subjectEncoding;
    			mailMessage.Priority = this.Priority;
    
    			#region on ajoute la ou les pièce(s) jointe(s)
    			if (!string.IsNullOrEmpty(Attachment))
    			{
    				var attachments = Attachment.Split(';');
    				foreach (var attach in attachments)
    				{
    					if (!string.IsNullOrEmpty(attach.Trim()))
    					{
    						var path = attach.Trim();
    						try
    						{
    							var context = HttpContext.Current;
    							if (context == null) //context non web
    							{
    								//on teste s'il s'agit d'un chemin absolu ou non
    								if (!Path.IsPathRooted(path))
    								{
    									path = Directory.GetCurrentDirectory() + "\\" + path;
    								}
    
    								if (File.Exists(path))
    								{
    									//si le fichier spécifié existe bien, on l'ajoute en pièce jointe au mail
    									AttachFile(mailMessage, path);
    								}
    								else
    								{
    									// Sinon, on écrit dans le corps du mail que le fichier n'a pas été trouvé
    									mailMessage.Body += IsBodyHtml ? "<br/>" : Environment.NewLine;
    									mailMessage.Body += IsBodyHtml ? "<br/>" : Environment.NewLine;
    									mailMessage.Body += "Fichier non trouvé: " + attach;
    								}
    							}
    							else //context web
    							{
    								//on teste s'il s'agit d'un chemin absolu ou non
    								if (!Path.IsPathRooted(path))
    								{
    									path = context.Server.MapPath(path);
    								}
    
    								if (File.Exists(path))
    								{
    									//si le fichier spécifié existe bien, on l'ajoute en pièce jointe au mail
    									AttachFile(mailMessage, path);
    								}
    								else
    								{
    									// Sinon, on écrit dans le corps du mail que le fichier n'a pas été trouvé
    									mailMessage.Body += IsBodyHtml ? "<br/>" : Environment.NewLine;
    									mailMessage.Body += IsBodyHtml ? "<br/>" : Environment.NewLine;
    									mailMessage.Body += "Fichier non trouvé: " + attach;
    								}
    							}
    						}
    						catch (Exception ex)
    						{
    							// En cas d'erreur, on précise dans le corps du mail que le fichier n'a pu être joint
    							mailMessage.Body += IsBodyHtml ? "<br/>" : Environment.NewLine;
    							mailMessage.Body += IsBodyHtml ? "<br/>" : Environment.NewLine;
    							mailMessage.Body += string.Format("<b>Erreur lors de l'ajout de la piece jointe: {0}</b>", attach);
    
    							// On logge l'erreur avec le logger interne de log4net
    							VPLog.Log4Net.Log.log.Error(string.Format("Erreur lors de la pièe jointe: {0} (path: {1})", attach, path), ex);
    						}
    						finally
    						{
    							this.Attachment = "";
    						}
    					}
    				}
    			}
    			#endregion
    
    			// TODO: Consider using SendAsync to send the message without blocking. This would be a change in
    			// behaviour compared to .NET 1.x. We would need a SendCompletedCallback to log errors.
    			smtpClient.Send(mailMessage);
    		}
    	}
    
    
    	/// <summary>
    	/// On permet la customisation de l'objet du mail
    	/// </summary>
    	/// <param name="loggingEvent"></param>
    	protected override void Append(log4net.Core.LoggingEvent loggingEvent)
    	{
    		if (this.BufferSize <= 1 && this.LayoutSubject != null)
    		{
    			#region Custo pour le sujet
    			var subjectWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);
    			LayoutSubject.Format(subjectWriter, loggingEvent);
    			this.Subject = subjectWriter.ToString();
    		#endregion
    	}
    	base.Append(loggingEvent);
    }
    
    /// <summary>
    /// Attache une pièce jointe au mail
    /// </summary>
    /// <param name="mailMessage">mailMessage</param>
    /// <param name="path">Chemin du fichier</param>
    private void AttachFile(System.Net.Mail.MailMessage mailMessage, string path)
    {
    	var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    	mailMessage.Attachments.Add(new Attachment(stream, Path.GetFileName(Attachment)));
    	}
    }
