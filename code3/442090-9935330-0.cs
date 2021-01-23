    findResults = exchangeService.FindItems(folder.Id, messageFilter, view);
                foreach (Item item in findResults)
                {
                    if (item is EmailMessage)
                    {
                        EmailMessage message;
                        if (!toFromDetails)
                            message = (EmailMessage)item;
                        else
                            message = EmailMessage.Bind(exchangeService, item.Id);
