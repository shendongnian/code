    class Program
	{
		public static void Main(string[] args)
		{
			try {
				ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
				service.Credentials = new WebCredentials("login","pwd");
				service.AutodiscoverUrl("mail@domaine.com");
                ItemView view = new ItemView(10);
                FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(10));
                
                if (findResults != null && findResults.Items != null && findResults.Items.Count > 0)
                    foreach (Item item in findResults.Items)
                    {
                        EmailMessage message = EmailMessage.Bind(service, item.Id, new PropertySet(BasePropertySet.IdOnly, ItemSchema.Attachments, ItemSchema.HasAttachments));
                        foreach (Attachment attachment in message.Attachments)
                        {
                            if (attachment is FileAttachment)
                            {
                                FileAttachment fileAttachment = attachment as FileAttachment;
                                fileAttachment.Load();
                                Console.WriteLine("Attachment name: " + fileAttachment.Name);
                            }
                        }
                        Console.WriteLine(item.Subject);
                    }
                else
                    Console.WriteLine("no items");
			} catch (Exception e) {
				
				Console.WriteLine(e.Message);
			}
			Console.ReadLine();
		}
	}
