    foreach (Item myItem in findResults.Items.Where(i=>i is EmailMessage))
            {
                    var mailItem =myItem as EmailMessage;
                    Console.WriteLine(mailItem.Subject);
                    mailItem.Load(new PropertySet(BasePropertySet.FirstClassProperties) { RequestedBodyType = BodyType.Text }); // Adding this parameter does the trick :)
                    Console.WriteLine(mailItem.Body.Text);
                    if(! mailItem.IsRead)
                        Console.WriteLine("Who is Your Daddy!!!!");
                
            }
