    public void SendMailCollection(IEnumerable<Tuple<string, string, MailAddress>> mailParams)
		{
			var smtpClient = new SmtpClient
			{
				Credentials = new NetworkCredential(_configurationService.SmtpUser, _configurationService.SmtpPassword),
				Host = _configurationService.SmtpHost,
				Port = _configurationService.SmtpPort.Value
			};
			
			var task = new Task(() =>
			                    	{
			                    		foreach (MailMessage message in mailParams.Select(FormMessage))
			                    		{
			                    			smtpClient.Send(message);
			                    		}
			                    		
			                    	});
			task.Start();
		}
		private MailMessage FormMessage(Tuple<string, string, MailAddress> firstMail)
		{
			var message = new MailMessage
				{
					From = new MailAddress(_configurationService.SmtpSenderEmail, _configurationService.SmtpSenderName),
					Subject = firstMail.Item1,
					Body = firstMail.Item2
				};
			message.To.Add(firstMail.Item3);
			return message;
		}
