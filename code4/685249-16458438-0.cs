    public void RaiseAlert(string message)
	{
		var alert = builder.CreateAlert();
		alert.IsSystemWide = true;
		alert.Content = CreateAlertContent(message);
		var receivers = GetAlertReceivers(alert);
		
		smsService.SendSmsAsync(alert.Content, receivers);
		emailService.SendEmailAsync(alert.Content, receivers);
	}
	
