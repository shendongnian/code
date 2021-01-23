    public class Outlook
    {
        /// <summary>
        /// Returns the selected node Index which equals selected mail index.
        /// </summary>
        public static Int32 selectedMailindex
        {
            get
            {
                return (Int32)Form1.GlobalAccess.Invoke((Func<int>)delegate
                {
                    return Form1.GlobalAccess.mailTree.SelectedNode.Index;
                }); 
            }
        }
        static PullSubscription subscriptionInbox;
        public static ExchangeService runningService;
        /// <summary>
        /// Used to save EmailMessage retrieved from user inbox.
        /// </summary>
        public static List<EmailMessage> mailMessages = new List<EmailMessage>();
        /// <summary>
        /// We start the procedure to grab Emails.
        /// </summary>
        public static void StartupLoadMails()
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            service.TraceEnabled = true;
            service.Credentials = new WebCredentials("username", "password"); //Modify this
            service.Url = new Uri("Exchange.asmx URL"); //Modify this
            GetBinding(service);
            runningService = service;
            GetMailItems(runningService);
        }
        static ExchangeService GetBinding(ExchangeService service)
        {
            //Subscribe to Inbox newmail/modified events.
            subscriptionInbox = service.SubscribeToPullNotifications(
            new FolderId[] { WellKnownFolderName.Inbox }, //Inbox
            5, //TimeOut
            null,
            EventType.NewMail, EventType.Modified); //NewMail or Modified
            // Display the service URL.
            return service;
        }
        /*static bool RedirectionUrlValidationCallback(String redirectionUrl)
        {
            return true;
        }*/
        public static void GetMailItems(ExchangeService service)
        {
            Form1.GlobalAccess.Invoke(new Action(() =>
            {
                Form1.GlobalAccess.mailTree.Nodes.Clear();                
            }));
            mailMessages.Clear();
            //SearchFilter to get unreaded messages only.
            SearchFilter sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
            //Create new Item view with the last 9 unreaded items.
            ItemView view = new ItemView(9);
            //Execute the query
            FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, sf, view);
            //We use Parallel for faster initial app loading, reducing ~5/10 secs.
            Parallel.ForEach(findResults, item =>
                {
                    try
                    {
                        EmailMessage message = EmailMessage.Bind(service, item.Id);
                        mailMessages.Add(message);
                    }
                    catch
                    {
                        MessageBox.Show("ERROR");
                    }
                });
            //Since we used parallel we need to sort the emails in our EmailMessage LIST by date, so they show cronologicaly over the treeview.
            mailMessages.Sort(delegate(EmailMessage m1, EmailMessage m2) { return m2.DateTimeReceived.Date.CompareTo(m1.DateTimeReceived.Date); });
            foreach (EmailMessage m in mailMessages)
            {
                Form1.GlobalAccess.Invoke(new Action(() =>
                {
                    Form1.GlobalAccess.mailTree.Nodes.Add(m.Subject + " : " + m.Sender.Name);
                }));
            }
        }
        /// <summary>
        /// Calls threaded MarkReaded function to mark an Email as readed localy and remotly.
        /// </summary>
        public static void MarkReaded()
        {
            Thread thread = new Thread(CallThreadedReadFunction);
            thread.Priority = ThreadPriority.AboveNormal;
            thread.Start();
        }
        static void CallThreadedReadFunction()
        {
            ReadFunction(Outlook.mailMessages[selectedMailindex],selectedMailindex,runningService);
        }
        /// <summary>
        /// Mark as readed
        /// </summary>
        /// <param name="message">E-mail Message</param>
        /// <param name="index">Index Message Possition</param>
        /// <param name="service">EWS Service</param>
        static void ReadFunction(EmailMessage message, Int32 index, ExchangeService service)
        {
            Form1.GlobalAccess.Invoke(new Action(() =>
            {
                Form1.GlobalAccess.mailTree.Nodes[index].SelectedImageIndex = 3;
                Form1.GlobalAccess.mailTree.Nodes[index].ImageIndex = 3;
            }));
            EmailMessage msg = EmailMessage.Bind(service, message.Id);
            msg.IsRead = true;
            msg.Update(ConflictResolutionMode.AutoResolve);
        }
        /// <summary>
        /// Calls threaded Delete function to delete an Email localy and remotly.
        /// </summary>
        public static void Delete()
        {
            var deleteWorker = new BackgroundWorker();
            deleteWorker.DoWork += (sender, args) =>
            {
                DeleteFunction(Outlook.mailMessages[selectedMailindex], selectedMailindex, runningService);
            };
            deleteWorker.RunWorkerCompleted += (sender, args) =>
            {
                if (args.Error != null)
                    MessageBox.Show(args.Error.ToString());
                Form1.GlobalAccess.Invoke(new Action(() =>
                {
                    Form1.GlobalAccess.mailrefreshIcon.Visible = true;
                }));
            };
            deleteWorker.RunWorkerAsync();
        }
        /// <summary>
        /// Delete Emails choosen by the user.
        /// </summary>
        /// <param name="message">E-mail Message</param>
        /// <param name="index">Index Message Possition</param>
        /// <param name="service">EWS Service</param>
        public static void DeleteFunction(EmailMessage message, Int32 index, ExchangeService service)
        {
            try
            {
                Form1.GlobalAccess.Invoke(new Action(() =>
                {
                    Form1.GlobalAccess.mailTree.Nodes.RemoveAt(index);
                    mailMessages.RemoveAt(index);
                    Form1.GlobalAccess.mailTree.SelectedNode = null;
                    Form1.GlobalAccess.mailBrowser.DocumentText = null;
                }));
                EmailMessage msg = EmailMessage.Bind(service, message.Id);
                msg.Delete(DeleteMode.MoveToDeletedItems);
                msg.Update(ConflictResolutionMode.AlwaysOverwrite);
            }
            catch
            {
                //En ocaciones, si se borran muchos emails consecutivamente y se da refresh al inbox rapidamente, causa un crash porque el servidor encuentra el email que ordenamos borrar y mientras esta
                //Iterando es borrado, causando un crash. Lo mejor es unicamente ignorar la excepción, el programa seguira trabajando bien.
            }
        }
        /// <summary>
        /// Listens for new mails in the user inbox folder, if found, notifies the user and update mail list.
        /// </summary>
        /// <param name="service">EWS Service</param>
        public static void GetLatests(ExchangeService service)
        {
            GetEventsResults eventsInbox = subscriptionInbox.GetEvents();
            EmailMessage message;
            // Loop through all item-related events.
            foreach (ItemEvent itemEvent in eventsInbox.ItemEvents)
            {
                switch (itemEvent.EventType)
                {
                    case EventType.NewMail:
                        try
                        {
                            Item item = Item.Bind(service, itemEvent.ItemId);
                            if (item.ItemClass.ToLower() == "IPM.Note".ToLower())
                            {
                                message = EmailMessage.Bind(service, itemEvent.ItemId);
                                    Form1.GlobalAccess.Invoke(new Action(() =>
                                    {
                                    if (Form1.GlobalAccess.mailTree.Nodes.Count == 8)
                                    {
                                        try
                                        {
                                            Form1.GlobalAccess.mailTree.Nodes.RemoveAt(8);
                                            mailMessages.RemoveAt(8);
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    Form1.GlobalAccess.mailTree.Nodes.Insert(0, message.Subject);
                                    mailMessages.Insert(0, message);
                                    }));
                                }               
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Reply to a single user. This method gets called from ReplyMail winform.
        /// </summary>
        /// <param name="message">Email Message OBJECT</param>
        /// <param name="index">Email position in the tree</param>
        /// <param name="service">EWS Current Service</param>
        /// <param name="bodyText">Message Text</param>
        /// <param name="subject">Message Original Subject</param>
        public static void Reply(EmailMessage message, Int32 index, ExchangeService service, String bodyText, String subject)
        {
            var replyWorker = new BackgroundWorker();
            replyWorker.DoWork += (sender, args) =>
            {
                bool replyToAll = false;
                ResponseMessage responseMessage = message.CreateReply(replyToAll);
                responseMessage.BodyPrefix = bodyText;
                responseMessage.Subject = subject;
                responseMessage.SendAndSaveCopy();
            };
            replyWorker.RunWorkerCompleted += (sender, args) =>
            {
                if (args.Error != null)
                    MessageBox.Show(args.Error.ToString());
                ReplyMail.GlobalAccess.Invoke(new Action(() =>
                {
                    ReplyMail.GlobalAccess.mailSentPic.Visible = true;
                    ReplyMail.GlobalAccess.MailSentTxt.Visible = true;
                    ReplyMail.GlobalAccess.button2.Visible = true;
                }));
            };
            replyWorker.RunWorkerAsync();
            
        }
        /// <summary>
        /// Forward an E-mail, lets you introduce recipients.
        /// </summary>
        /// <param name="message">EMAILMESSAGE</param>
        /// <param name="index">Mail position on the treeview</param>
        /// <param name="service">EWS Service</param>
        /// <param name="addresses">List with the mail adresses that the user is forwarding to</param>
        public static void Forward(EmailMessage message, Int32 index, ExchangeService service, List<EmailAddress> addresses)
        {
            var forwardWorker = new BackgroundWorker();
            forwardWorker.DoWork += (sender, args) =>
            {
                message.Forward(message.Body.Text, addresses);
            };
            forwardWorker.RunWorkerCompleted += (sender, args) =>
            {
                if (args.Error != null)
                    MessageBox.Show(args.Error.ToString());
                ReplyMail.GlobalAccess.Invoke(new Action(() =>
                {
                    ReplyMail.GlobalAccess.mailSentPic.Visible = true;
                    ReplyMail.GlobalAccess.MailSentTxt.Visible = true;
                    ReplyMail.GlobalAccess.button2.Visible = true;
                }));
            };
            forwardWorker.RunWorkerAsync();            
        }
        /// <summary>
        /// Send a single E-Mail
        /// </summary>
        /// <param name="service">EWS Service</param>
        /// <param name="subject">EMAILMESSAGE subject</param>
        /// <param name="bodyText">EMAILMESSAGE body.text</param>
        /// <param name="destination">EMAILADDRESS from receiver</param>
        public static void Send(ExchangeService service, String subject, String bodyText, String destination)
        {
            var sendWorker = new BackgroundWorker();
            sendWorker.DoWork += (sender, args) =>
            {
                EmailMessage message = new EmailMessage(service);
                message.Subject = subject;
                message.Body = bodyText;
                message.ToRecipients.Add(destination);
                message.SendAndSaveCopy();
            };
            sendWorker.RunWorkerCompleted += (sender, args) =>
            {
                if (args.Error != null)
                    MessageBox.Show(args.Error.ToString());
                ReplyMail.GlobalAccess.Invoke(new Action(() =>
                {
                    ReplyMail.GlobalAccess.mailSentPic.Visible = true;
                    ReplyMail.GlobalAccess.MailSentTxt.Visible = true;
                    ReplyMail.GlobalAccess.button2.Visible = true;
                }));
            };
            sendWorker.RunWorkerAsync();           
        }
    }
}
