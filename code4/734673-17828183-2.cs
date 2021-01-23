    foreach (Item myItem in findResults.Items)
            {
                if (myItem is EmailMessage)
                {
                    var mailItem =myItem as EmailMessage;
                    Console.WriteLine(mailItem.Subject);
                    mailItem.Load();
                    Console.WriteLine(mailItem.Body.Text);
                    if(! mailItem.IsRead)
                        Console.WriteLine("Who is Your Daddy!!!!");
                }
            }
