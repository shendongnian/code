    using System.Net.Mail;
    using System.Net.Mime;
    
    namespace MailMessageHTML
    {
    	class Program
    	{
    
    		private static MailMessage ConstructMessage(string from, string to, string subject)
    		{
    			const string textPlainContent =@"You need a HTML-capable mail agent to read this message.";
    			const string textHtmlContent =@"<html><head><link rel='stylesheet' type='text/css' href='cid:myMagicStyle' />
    </head>
    <body>
    <h2>Hello world!</h2>
    <p>This is a test HTML e-mail message.</p>
    </body>
    </html>
    ";
        
       MailMessage result = new MailMessage(from, to, subject, textPlainContent);
       LinkedResource cssResource = new LinkedResource("myMagic.css", "text/css");
       //NOTE: Message encoding adds the surrounding <> on this Id cssResource.ContentId =myMagicStyle";
       cssResource.TransferEncoding = TransferEncoding.SevenBit;
        
          AlternateView htmlBody = AlternateView.CreateAlternateViewFromString( textHtmlContent , new ContentType("text/html"));
    			htmlBody.TransferEncoding = TransferEncoding.SevenBit;
    			htmlBody.LinkedResources.Add(cssResource);
    
    			result.AlternateViews.Add(htmlBody);
    
    			return result;
    		}
    
    		static void Main(string[] args)
    		{
    			MailMessage foo = ConstructMessage(
            "sender@foo.com"
    				,"recipient@bar.com"
    				, "Test HTML message with style."
    				);
    			SmtpClient sender = new SmtpClient();
    			sender.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
    			sender.PickupDirectoryLocation = @"...\MailMessageHTML\bin\Debug\";
    			sender.Send(foo);
    		}
    	}
    }
 
 
 
