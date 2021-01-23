	catch (SmtpFailedRecipientsException e)
	{
		string sFailedEmailIds = "";
		for (int i = 0; i < e.InnerExceptions.Length; i++)
		{
			SmtpStatusCode status = e.InnerExceptions[i].StatusCode;
			if (status == SmtpStatusCode.MailboxBusy ||
			    status == SmtpStatusCode.MailboxUnavailable) {
				sFailedEmailIds += e.InnerExceptions[i].FailedRecipient.Split('<', '>')[1] + ", ";
			} else {
				// other statuscode that you want to handle
			}
		}
		return sFailedEmailIds;
	}
