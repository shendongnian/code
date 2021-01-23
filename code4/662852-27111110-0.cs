	private static MemoryStream ConvertMailMessageToMemoryStream(MailMessage message)
	{
		Assembly systemAssembly = typeof(SmtpClient).Assembly;
		Type mailWriterType = systemAssembly.GetType("System.Net.Mail.MailWriter");
		const BindingFlags nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
		ConstructorInfo mailWriterContructor = mailWriterType.GetConstructor(nonPublicInstance, null, new[]  typeof(Stream) }, null);
		MethodInfo sendMethod = typeof(MailMessage).GetMethod("Send", nonPublicInstance);
		MethodInfo closeMethod = mailWriterType.GetMethod("Close", nonPublicInstance);
		using (MemoryStream memoryStream = new MemoryStream())
		{
			object mailWriter = mailWriterContructor.Invoke(new object[] { memoryStream });
			//AssertHelper.IsTrue(sendMethod.GetParameters().Length > 2, ".NET framework must be 4.5 or higher in order to properly encode email subject.");
			sendMethod.Invoke(message, nonPublicInstance, null,
				new[] { mailWriter, true, false },
				null);
			closeMethod.Invoke(mailWriter, nonPublicInstance, null, new object[] { }, null);
			return memoryStream;
		}
	}
