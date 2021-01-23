            using (ImapClient ic = new ImapClient("imap.gmail.com", 
                        "anemail@example.org", 
                        "PasswordGoesHere!", 
                        ImapClient.AuthMethods.Login, 
                        993, true))
            {
                ic.SelectMailbox("INBOX");
                Console.WriteLine(ic.ListMailboxes("",""));
                // Note that you must specify that headersonly = false
                // when using GetMesssages().
                MailMessage[] mm = ic.GetMessages(0, 10, false);
                
                foreach (MailMessage m in mm)
                {
                    Console.WriteLine(m.From);
                    Console.WriteLine(m.Body);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
