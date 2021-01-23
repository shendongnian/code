		HttpPostedFile hpf = hfc[i];
		
		if (hpf.ContentLength > 0)
		{
			hpf.InputStream.Position = 0;
		
			if (i == 0)
			{
				string[] ext = System.IO.Path.GetFileName(hpf.FileName).Split('.');
				attachId = filename + "." + ext[1];
				at = new System.Net.Mail.Attachment(hpf.InputStream, attachId);
			}
			else
			{
				string[] ext = System.IO.Path.GetFileName(hpf.FileName).Split('.');
				attachId = filename + "(" + i + ")" + "." + ext[1];
				at = new System.Net.Mail.Attachment(hpf.InputStream, attachId);
			}
                 
			message.Attachments.Add(at);
		}
