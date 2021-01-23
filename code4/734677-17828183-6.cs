    foreach (Item myItem in findResults.Items.Where(i=>i is EmailMessage))
            {
                    var mailItem =myItem as EmailMessage;
                    Console.WriteLine(mailItem.Subject);
                    mailItem.Load();
                    Console.WriteLine(mailItem.Body.Text);
                    if(! mailItem.IsRead)
                        Console.WriteLine("Who is Your Daddy!!!!");                
            }
