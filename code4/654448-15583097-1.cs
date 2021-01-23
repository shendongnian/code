	void Main()
	{
		SendHtmlBody(GetHtmlBody());
	}
	void SendHtmlBody(string HtmlBody){
		using(SmtpClient c = new SmtpClient())
		{
			//set smtp options here
			using(MailMessage msg = new MailMessage("from@replace.me","to@replace.me"))
			{
				msg.Subject = "Testing Bulk mail application";
				msg.Body = HtmlBody;
				msg.IsBodyHtml = true;
				//c.Send(msg);
			}
		}
	}
	string GetHtmlBody(){
		string xmlInput = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
		<EmailTemplate>
		<subject>Information from xyz</subject>
		<displayName>abcd</displayName>
		<Message1>
			Thanks you for registering to xyz.
		</Message1>
		<Copyright>Copyright xyz</Copyright>
		</EmailTemplate>";
		
			string xslInput = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
		<xsl:stylesheet version=""1.0""
		xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
		<xsl:template match=""/"">
		<html>
		<body>
			<h5><xsl:value-of select=""EmailTemplate/subject""/></h5>
			<h5><xsl:value-of select=""EmailTemplate/displayName""/></h5>
		</body>
		</html>
		</xsl:template>
		</xsl:stylesheet>";
		
		using (StringReader srt = new StringReader(xslInput)) // xslInput is a string that contains xsl
		using (StringReader sri = new StringReader(xmlInput)) // xmlInput is a string that contains xml
		{
			using (XmlReader xrt = XmlReader.Create(srt))
			using (XmlReader xri = XmlReader.Create(sri))
			{
				XslCompiledTransform xslt = new XslCompiledTransform();
				xslt.Load(xrt);
				using (StringWriter sw = new StringWriter())
				using (XmlWriter xwo = XmlWriter.Create(sw, xslt.OutputSettings)) // use OutputSettings of xsl, so it can be output as HTML
				{
					xslt.Transform(xri, xwo);
					return sw.ToString();
				}
			}
		}
	}
