	public static class MailMessageExt
	{
		public static void Save(this MailMessage Message, string FileName)
		{
			Assembly assembly = typeof(SmtpClient).Assembly;
			Type _mailWriterType = 
			  assembly.GetType("System.Net.Mail.MailWriter");
			using (FileStream _fileStream = 
				   new FileStream(FileName, FileMode.Create))
			{
				// Get reflection info for MailWriter contructor
				ConstructorInfo _mailWriterContructor =
					_mailWriterType.GetConstructor(
						BindingFlags.Instance | BindingFlags.NonPublic,
						null,
						new Type[] { typeof(Stream) }, 
						null);
				// Construct MailWriter object with our FileStream
				object _mailWriter = 
				  _mailWriterContructor.Invoke(new object[] { _fileStream });
				// Get reflection info for Send() method on MailMessage
				MethodInfo _sendMethod =
					typeof(MailMessage).GetMethod(
						"Send",
						BindingFlags.Instance | BindingFlags.NonPublic);
				// Call method passing in MailWriter
				_sendMethod.Invoke(
					Message,
					BindingFlags.Instance | BindingFlags.NonPublic,
					null,
					new object[] { _mailWriter, true },
					null);
				// Finally get reflection info for Close() method on our MailWriter
				MethodInfo _closeMethod =
					_mailWriter.GetType().GetMethod(
						"Close",
						BindingFlags.Instance | BindingFlags.NonPublic);
				// Call close method
				_closeMethod.Invoke(
					_mailWriter,
					BindingFlags.Instance | BindingFlags.NonPublic,
					null,
					new object[] { },
					null);
			}
		}
	}
