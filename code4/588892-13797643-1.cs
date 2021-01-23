	using System;
	namespace ScratchApp
	{
		internal class Program
		{
			private static void Main(string[] args)
			{
				var mailTemplate = BuildMailTemplate(
					mt => mt.MailBody = "hello world", 
					mt => mt.MailFrom = "rdingwall@gmail.com");
			}
			private static MailTemplate BuildMailTemplate(
				Action<MailTemplate> configAction1, 
				Action<MailTemplate> configAction2)
			{
				var mailTemplate = new MailTemplate();
				mailTemplate.ConfigureWith(configAction1)
					.ConfigureWith(configAction2)
					.DoSomeOtherStuff()
					.Build();
				return mailTemplate;
			}
		}
		public class MailTemplate
		{
			public string MailFrom { get; set; }
			public string MailBody { get; set; }
			public MailTemplate DoSomeOtherStuff()
			{
				// Do something
				return this;
			}
			public MailTemplate Build()
			{
				// Build something
				return this;
			}
			public MailTemplate ConfigureWith(Action<MailTemplate> func)
			{
				func(this);
				return this;
			}
		}
	}
